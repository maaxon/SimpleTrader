using System.Windows.Input;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.WPF.ViewModels
{
    public class QueueItemViewModel
    {
        private AssetQueue _assetQueue;

        public string Symbol => _assetQueue.Symbol;
        public double Price => _assetQueue.Price;
        public string Mode => _assetQueue.Mode;
        public AssetQueue Asset => _assetQueue;
        
        public ICommand RemoveTransaction { get; set; }
        
        public QueueItemViewModel(AssetQueue assetQueue, ICommand command)
        {
            _assetQueue = assetQueue;
            RemoveTransaction = command;
        }
    }
}