using System.Collections.Generic;
using FancyCandles;

namespace SimpleTrader.WPF.Helpers
{
    public class CandlesSource :
        System.Collections.ObjectModel.ObservableCollection<ICandle>, ICandlesSource
    {
        public CandlesSource(TimeFrame timeFrame)
        {
            this.timeFrame = timeFrame;
        }

        private readonly TimeFrame timeFrame;
        public TimeFrame TimeFrame { get { return timeFrame; } }
    }
}