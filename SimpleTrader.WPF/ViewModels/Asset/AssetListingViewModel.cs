using SimpleTrader.WPF.State.Assets;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.State.StockStore;

namespace SimpleTrader.WPF.ViewModels
{
    public class AssetListingViewModel : ViewModelBase
    {
        private readonly AssetStore _assetStore;
        private readonly Func<IEnumerable<AssetViewModel>, IEnumerable<AssetViewModel>> _filterAssets;
        private ObservableCollection<AssetViewModel> _assets;
        private readonly IRenavigator _renavigator;
        public IEnumerable<AssetViewModel> Assets => _assets;
        private readonly StockStore _stockStore;
        public ICommand ViewStock { get; }
        public AssetListingViewModel(AssetStore assetStore, IRenavigator stockRenavigator,StockStore stockStore) : this(assetStore,
            assets => assets,stockRenavigator,stockStore)
        {
            ViewStock = new ViewStockCommand(stockRenavigator,stockStore);
        }
        
        public AssetListingViewModel(AssetStore assetStore) : this(assetStore,
            assets => assets)
        {
            
           
        }
    
        public AssetListingViewModel(AssetStore assetStore, Func<IEnumerable<AssetViewModel>, IEnumerable<AssetViewModel>> filterAssets, IRenavigator renavigator, StockStore stockStore)
        {
            _assetStore = assetStore;
            _stockStore = stockStore;
            _filterAssets = filterAssets;
            _assets = new ObservableCollection<AssetViewModel>();
            _renavigator = renavigator;
            _assetStore.StateChanged += AssetStore_StateChanged;
            ResetAssets();
        }

        public AssetListingViewModel(AssetStore assetStore, Func<IEnumerable<AssetViewModel>, IEnumerable<AssetViewModel>> filterAssets)
        {
            _assetStore = assetStore;
            _filterAssets = filterAssets;
            _assets = new ObservableCollection<AssetViewModel>();
            _assetStore.StateChanged += AssetStore_StateChanged;
            ResetAssets();
        }
        
        private void ResetAssets()
        {
            IEnumerable<AssetViewModel> assetViewModels = _assetStore.AssetTransactions
                .GroupBy(t => t.Asset.Symbol)
                .Select(g => new AssetViewModel(g.Key, g.Sum(a => a.IsPurchase ? a.Shares : -a.Shares),_renavigator,_stockStore))
                .Where(a => a.Shares > 0)
                .OrderByDescending(a => a.Shares);

            assetViewModels = _filterAssets(assetViewModels);

            DisposeAssets();
            _assets.Clear();
            foreach (AssetViewModel viewModel in assetViewModels)
            {
                _assets.Add(viewModel);
            }
        }

        private void DisposeAssets()
        {
            foreach (AssetViewModel asset in _assets)
            {
                asset.Dispose();
            }
        }

        private void AssetStore_StateChanged()
        {
            ResetAssets();
        }

        public override void Dispose()
        {
            _assetStore.StateChanged -= AssetStore_StateChanged;
            DisposeAssets();

            base.Dispose();
        }
    }
}
