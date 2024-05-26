using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.Domain.Services.AuthenticationServices;
using SimpleTrader.Domain.Services.TransactionServices;
using SimpleTrader.EntityFramework.Services;
using SimpleTrader.FinancialModelingPrepAPI.Services;
using Wpf.Ui;

namespace SimpleTrader.WPF.HostBuilders
{
    public static class AddServicesHostBuilderExtensions
    {
        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<IPasswordHasher, PasswordHasher>();

                services.AddSingleton<IAuthenticationService, AuthenticationService>();
                services.AddSingleton<IDataService<Account>, AccountDataService>();
                services.AddSingleton<IDataService<AssetQueue>, GenericDataService<AssetQueue>>();
                services.AddSingleton<IDataService<StockDescription>, StockDescriptionDataService>();
                services.AddSingleton<IStockDescriptionDataService, StockDescriptionDataService>();
                services.AddSingleton<IAccountService, AccountDataService>();
                services.AddSingleton<IStockPriceService, StockPriceService>();
                services.AddSingleton<IStockDescriptionService, StockDescriptionService>();
                services.AddSingleton<IBuyStockService, BuyStockService>();
                services.AddSingleton<ISellStockService, SellStockService>();
                services.AddSingleton<IAddToQueueService, AddToQueueService>();
                services.AddSingleton<IMajorIndexService, MajorIndexService>();
                services.AddSingleton<IContentDialogService, ContentDialogService>();
                services.AddSingleton<ISnackbarService, SnackbarService>();
                services.AddSingleton<IContentDialogService, ContentDialogService>();
                services.AddSingleton<IDataService<AssetTransaction>, GenericDataService<AssetTransaction>>();
            });

            return host;
        }
    }
}
