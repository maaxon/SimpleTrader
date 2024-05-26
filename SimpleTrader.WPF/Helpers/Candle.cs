using System;
using FancyCandles;

namespace SimpleTrader.WPF.Helpers
{
    public class Candle : ICandle
    {
        public DateTime t { get; set; }
        public double O { get; set; }
        public double H { get; set; }
        public double L { get; set; }
        public double C { get; set; }
        public double V { get; set; }

        public Candle(DateTime t, double O, double H, double L, double C, double V)
        {
            this.t = t;
            this.O = O;
            this.H = H;
            this.L = L;
            this.C = C;
            this.V = V;
        }
    }
}