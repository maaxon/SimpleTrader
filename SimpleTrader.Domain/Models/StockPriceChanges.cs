using System;
using System.ComponentModel;
using System.Windows;
namespace SimpleTrader.Domain.Models
{
    public class StockPriceChanges: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public double Open { get; set; }
        public double Low { get; set; }
        public double High { get; set; }
        public double Close { get; set; }
        public int Volume { get; set; }
        public DateTime Date { get; set; }
        private Visibility _visibility = Visibility.Hidden;
        public Visibility PointVisibility
        {
            get { return _visibility; }
            set
            {
                _visibility = value;
                OnPropertyChanged("PointVisibility");
            }
        }
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}