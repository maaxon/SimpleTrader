﻿using System;
using System.Collections.Generic;
using SimpleTrader.Domain.Exceptions;
using System.Threading.Tasks;
using SimpleTrader.Domain.Models;
using SimpleTrader.FinancialModelingPrepAPI.Results;


namespace SimpleTrader.Domain.Services
{
    
  
    public interface IStockPriceService
    {
        /// <summary>
        /// Get the share price for a symbol.
        /// </summary>
        /// <param name="symbol">The symbol to get the price of.</param>
        /// <returns>The price of symbol.</returns>
        /// <exception cref="InvalidSymbolException">Thrown if symbol does not exist.</exception>
        /// <exception cref="Exception">Thrown if getting the symbol fails.</exception>
        Task<double> GetPrice(string symbol);

        Task<double> GetLocalPrice(string symbol);

        Task<List<StockPrice>> GetPrices();
        Task<List<StockPriceResult>> SearchPrices(string query);
    }
}
