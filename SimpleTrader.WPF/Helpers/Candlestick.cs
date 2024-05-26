using System;
using System.Collections.Generic;
using System.Linq;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.WPF.Helpers
{
     public class Candlestick
    {
        private const int PriceCount = 500;
        private const int PricesPerCandle = 10;

        public List<Price> Prices { get; } = new List<Price>(PriceCount + 1);
        public List<Candle> Candles { get; } = new List<Candle>(PriceCount / PricesPerCandle);
        public List<double> Labels { get; } = new List<double>();
        public double PriceCurrent { get; }
        public double PriceMin { get; }
        public double PriceMax { get; }
        public double PriceHeight { get; }

        public Candlestick(double lastPrice)
        {
            var rnd = new Random(1);
            var today = DateTime.Today;
            var date = DateTime.Today;
            var value = 300;
            for (var i = 0; i < Prices.Capacity; i++)
                Prices.Add(new Price { Date = date = date.AddMinutes(5), Value = value += rnd.Next(-9, 10) });
            Prices.Last().Value = lastPrice;
            for (var i = 0; i < Candles.Capacity; i++) {
                var prices = Prices.Select(p => p.Value).Skip(i * PricesPerCandle).Take(PricesPerCandle + 1);
                Candles.Add(new Candle {
                    Date = (Prices[i * PricesPerCandle].Date - today).TotalMinutes / 5,
                    Min = prices.Min(), Max = prices.Max(), Height = prices.Max() - prices.Min(),
                    DeltaMin = prices.First(), DeltaMax = prices.Last(), DeltaHeight = Math.Abs(prices.Last() - prices.First()),
                    IsPositive = prices.First() < prices.Last(),
                });
            }
            Candles.ForEach(c => c.Fix());
            PriceCurrent = Prices.Last().Value;
            PriceMin = Prices.Min(p => p.Value) - 20;
            PriceMax = Prices.Max(p => p.Value) + 20;
            PriceHeight = PriceMax - PriceMin - 40;
            for (double price = Math.Round(PriceMin / 10) * 10; price < PriceMax; price += 50)
                Labels.Add(price);
        }
        
        public Candlestick()
        {
            var rnd = new Random(1);
            var today = DateTime.Today;
            var date = DateTime.Today;
            var value = 300;
            for (var i = 0; i < Prices.Capacity; i++)
                Prices.Add(new Price { Date = date = date.AddMinutes(5), Value = value += rnd.Next(-9, 10) });
            for (var i = 0; i < Candles.Capacity; i++) {
                var prices = Prices.Select(p => p.Value).Skip(i * PricesPerCandle).Take(PricesPerCandle + 1);
                Candles.Add(new Candle {
                    Date = (Prices[i * PricesPerCandle].Date - today).TotalMinutes / 5,
                    Min = prices.Min(), Max = prices.Max(), Height = prices.Max() - prices.Min(),
                    DeltaMin = prices.First(), DeltaMax = prices.Last(), DeltaHeight = Math.Abs(prices.Last() - prices.First()),
                    IsPositive = prices.First() < prices.Last(),
                });
            }
            Candles.ForEach(c => c.Fix());
            PriceCurrent = Prices.Last().Value;
            PriceMin = Prices.Min(p => p.Value) - 20;
            PriceMax = Prices.Max(p => p.Value) + 20;
            PriceHeight = PriceMax - PriceMin - 40;
            for (double price = Math.Round(PriceMin / 10) * 10; price < PriceMax; price += 50)
                Labels.Add(price);
        }
        
        public Candlestick(List<StockPriceChanges> stockPriceChangesList)
        {
            var rnd = new Random(1);
            var today = DateTime.Today;
            var date = DateTime.Today;
            var value = 300;
            for (var i = 0; i < Prices.Capacity; i++)
                Prices.Add(new Price { Date = stockPriceChangesList[i].Date, Value = stockPriceChangesList[i].High });

            for (var i = 0; i < Candles.Capacity; i++) {
                var prices = Prices.Select(p => p.Value).Skip(i * PricesPerCandle).Take(PricesPerCandle + 1);
                Candles.Add(new Candle {
                    Date = (Prices[i * PricesPerCandle].Date - today).TotalMinutes / 5,
                    Min = prices.Min(), Max = prices.Max(), Height = prices.Max() - prices.Min(),
                    DeltaMin = prices.First(), DeltaMax = prices.Last(), DeltaHeight = Math.Abs(prices.Last() - prices.First()),
                    IsPositive = prices.First() < prices.Last(),
                });
            }
            Candles.ForEach(c => c.Fix());
            PriceCurrent = Prices.Last().Value;
            PriceMin = Prices.Min(p => p.Value) - 20;
            PriceMax = Prices.Max(p => p.Value) + 20;
            PriceHeight = PriceMax - PriceMin - 40;
            for (double price = Math.Round(PriceMin / 10) * 10; price < PriceMax; price += 50)
                Labels.Add(price);
        }
    }

    public class Price
    {
        public DateTime Date { get; set; }
        public double Value { get; set; }
    }

    public class Candle
    {
        public double Date { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public double Height { get; set; }
        public double DeltaMin { get; set; }
        public double DeltaMax { get; set; }
        public double DeltaHeight { get; set; }
        public bool IsPositive { get; set; }

        public void Fix()
        {
            if (!IsPositive) {
                var min = DeltaMin;
                DeltaMin = DeltaMax;
                DeltaMax = min;
            }
        }
    }
}