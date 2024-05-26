using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.FinancialModelingPrepAPI.Results;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
  
    public class StockDescriptionService:IStockDescriptionService
    {
        private readonly FinancialModelingPrepHttpClient _client;

        public StockDescriptionService(FinancialModelingPrepHttpClient client)
        {
            _client = client;
        }

        public async Task<ApiStockDescription> GetStockDescription(string symbol)
        {
            string uri = "profile/" + symbol;

            List<ApiStockDescription> stockPriceResult = await _client.GetAsync<List<ApiStockDescription>>(uri);

            if(stockPriceResult.Count == 0)
            {
                throw new InvalidSymbolException(symbol);
            }

            return stockPriceResult[0];
        }

        public async Task<List<StockPriceChanges>> GetStockPriceChanges(string symbol)
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            DateTime dateTime2 = dateTime.AddDays(-10);
            string uri = "historical-chart/5min/" + symbol;
            string param = "&from=" + dateTime2.ToString("yyyy-MM-dd")
                                   + "&to=" + dateTime.ToString("yyyy-MM-dd");

            List<StockPriceChanges> stockPriceResult = await _client.GetAsync<List<StockPriceChanges>>(uri,param);

            if(stockPriceResult.Count == 0)
            {
                throw new InvalidSymbolException(symbol);
            }

            return stockPriceResult;
        }
    }
}