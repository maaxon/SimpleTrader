using SimpleTrader.WPF.State.Navigators;
using System;

namespace SimpleTrader.WPF.ViewModels.Factories
{
    public class SimpleTraderViewModelFactory : ISimpleTraderViewModelFactory
    {
        private readonly CreateViewModel<HomeViewModel> _createHomeViewModel;
        private readonly CreateViewModel<PortfolioViewModel> _createPortfolioViewModel;
        private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;
        private readonly CreateViewModel<BuyViewModel> _createBuyViewModel;
        private readonly CreateViewModel<SellViewModel> _createSellViewModel;
        private readonly CreateViewModel<StockViewModel> _createStockViewModel;
        private readonly CreateViewModel<SearchViewModel> _createSearchViewModel;
        private readonly CreateViewModel<UsersViewModel> _createUsersViewModel;
        private readonly CreateViewModel<AdminStocksViewModel> _createAdminStocksViewModel;
        private readonly CreateViewModel<AssetsQueueViewModel> _createAssetsQueueViewModel;
        
        public SimpleTraderViewModelFactory(
            CreateViewModel<HomeViewModel> createHomeViewModel,
            CreateViewModel<PortfolioViewModel> createPortfolioViewModel,
            CreateViewModel<LoginViewModel> createLoginViewModel,
            CreateViewModel<BuyViewModel> createBuyViewModel, 
            CreateViewModel<SellViewModel> createSellViewModel,
            CreateViewModel<StockViewModel> createStockViewModel,
            CreateViewModel<SearchViewModel> createSearchViewModel,
            CreateViewModel<UsersViewModel> createUsersViewModel,
            CreateViewModel<AdminStocksViewModel> createAdminStocksViewModel,
            CreateViewModel<AssetsQueueViewModel> createAssetsQueueViewModel)
        {
            _createHomeViewModel = createHomeViewModel;
            _createPortfolioViewModel = createPortfolioViewModel;
            _createLoginViewModel = createLoginViewModel;
            _createBuyViewModel = createBuyViewModel;
            _createSellViewModel = createSellViewModel;
            _createStockViewModel = createStockViewModel;
            _createSearchViewModel = createSearchViewModel;
            _createUsersViewModel = createUsersViewModel;
            _createAdminStocksViewModel = createAdminStocksViewModel;
            _createAssetsQueueViewModel = createAssetsQueueViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Login:
                    return _createLoginViewModel();
                case ViewType.Home:
                    return _createHomeViewModel();
                case ViewType.Portfolio:
                    return _createPortfolioViewModel();
                case ViewType.Buy:
                    return _createBuyViewModel();
                case ViewType.Sell:
                    return _createSellViewModel();
                case ViewType.Search:
                    return _createSearchViewModel();
                case ViewType.Users:
                    return _createUsersViewModel();
                case ViewType.AdminStocks:
                    return _createAdminStocksViewModel();
                case ViewType.AssetQueue:
                    return _createAssetsQueueViewModel();
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
