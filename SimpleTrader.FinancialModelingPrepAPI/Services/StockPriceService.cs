using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Services;
using SimpleTrader.FinancialModelingPrepAPI.Results;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    public class PriceData
    {
        public List<StockPrice> CompaniesPriceList { get; set; }
    }
    
    public class PricesData
    {
        public List<StockPrice> StockList { get; set; }
    }
    public class StockPriceService : IStockPriceService
    {
        private readonly FinancialModelingPrepHttpClient _client;
        private readonly IStockDescriptionDataService _service;

        public StockPriceService(FinancialModelingPrepHttpClient client,IStockDescriptionDataService service)
        {
            _client = client;
            _service = service;
        }

        public async Task<double> GetPrice(string symbol)
        {
           /* string uri = "stock/real-time-price/" + symbol;
            
            PriceData stockPriceResult = await _client.GetAsync<PriceData>(uri);

            if(stockPriceResult.CompaniesPriceList.Count == 0)
            {
                throw new InvalidSymbolException(symbol);
            }

            return stockPriceResult.CompaniesPriceList[0].Price;*/
           return await GetLocalPrice(symbol);
        }

        public async Task<double> GetLocalPrice(string symbol)
        {
            var stock =await _service.GetBySymbol(symbol);
            return stock.Price;
        }

        public async Task<List<StockPrice>> GetPrices()
        {
            string uri = "stock-screener";

            List<StockPrice> stockPriceResult = await _client.GetAsync<List<StockPrice>>(uri,"&limit=10");

            if(stockPriceResult.Count == 0)
            {
                throw new InvalidSymbolException("invalid request");
            }   

            return stockPriceResult;
        }
        
        public async Task<List<StockPriceResult>> SearchPrices(string query)
        {
            string uri = "search-ticker";
            string param = $"&query={query}&limit=4"; 

            List<SearchStockResult> searchStockResults = await _client.GetAsync<List<SearchStockResult>>(uri,param);
            List<StockPriceResult> stockPriceResult = new List<StockPriceResult>();
            if(searchStockResults.Count == 0)
            {
                throw new InvalidSymbolException("invalid request");
            }
           
            
            foreach (var res in searchStockResults)
            {
                    double price = await GetPrice(res.Symbol);
                    if (price > 0)
                    {
                        stockPriceResult.Add(new StockPriceResult(res.Symbol,price));
                    }
            }
            

            return stockPriceResult;
        }
    }
}
