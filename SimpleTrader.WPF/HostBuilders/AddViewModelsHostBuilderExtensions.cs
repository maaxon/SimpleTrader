using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleTrader.Domain.Services;
using SimpleTrader.WPF.State.Authenticators;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels;
using SimpleTrader.WPF.ViewModels.Factories;
using System;
using Microsoft.AspNet.Identity;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services.TransactionServices;
using SimpleTrader.WPF.State.Accounts;
using SimpleTrader.WPF.State.Assets;
using SimpleTrader.WPF.State.StockStore;
using SimpleTrader.WPF.State.UpdateStockStore;
using SimpleTrader.WPF.State.UsersStore;
using Wpf.Ui;

namespace SimpleTrader.WPF.HostBuilders
{
    public static class AddViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddTransient(CreateHomeViewModel);
                services.AddTransient<PortfolioViewModel>();
                services.AddTransient<BuyViewModel>();
                services.AddTransient<SellViewModel>();
                services.AddTransient<AssetSummaryViewModel>();
                services.AddTransient<MainViewModel>();
                services.AddTransient<StockViewModel>();
                services.AddTransient<SearchViewModel>();
                services.AddTransient<UsersViewModel>();
                services.AddTransient<CreateStockViewModel>();
                services.AddTransient<UpdateStockViewModel>();
                services.AddSingleton<CreateViewModel<HomeViewModel>>(services => () => services.GetRequiredService<HomeViewModel>());
                services.AddSingleton<CreateViewModel<PortfolioViewModel>>(services => () => CreatePortfolioViewModel(services));
                services.AddSingleton<CreateViewModel<BuyViewModel>>(services => () => CreateBuyViewModel(services));
                services.AddSingleton<CreateViewModel<SellViewModel>>(services => () => services.GetRequiredService<SellViewModel>());
                services.AddSingleton<CreateViewModel<StockViewModel>>(services => () => CreateStockViewModel(services));
                services.AddSingleton<CreateViewModel<LoginViewModel>>(services => () => CreateLoginViewModel(services));
                services.AddSingleton<CreateViewModel<RegisterViewModel>>(services => () => CreateRegisterViewModel(services));
                services.AddSingleton<CreateViewModel<SearchViewModel>>(services => () => services.GetRequiredService<SearchViewModel>());
                services.AddSingleton<CreateViewModel<UsersViewModel>>(services =>
                    () => CreateUsersViewModel(services));
                services.AddSingleton<CreateViewModel<AdminStocksViewModel>>(services =>
                    () => CreateAdminStocksViewModel(services));
                services.AddSingleton<CreateViewModel<UserViewModel>>(services => () => CreateUserViewModel(services));
                services.AddSingleton<CreateViewModel<CreateStockViewModel>>(services =>
                    () => services.GetRequiredService<CreateStockViewModel>());
                services.AddSingleton<CreateViewModel<UpdateStockViewModel>>(services => () => CreateUpdateStockViewModel(services));
                services.AddSingleton<CreateViewModel<AssetsQueueViewModel>>(services => () => CreateAssetsQueueViewModel(services));
                
                services.AddSingleton<ISimpleTraderViewModelFactory, SimpleTraderViewModelFactory>();
                
                services.AddSingleton<ViewModelDelegateRenavigator<HomeViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<LoginViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<RegisterViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<StockViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<UserViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<CreateStockViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<UpdateStockViewModel>>();
            });

            return host;
        }

        private static PortfolioViewModel CreatePortfolioViewModel(IServiceProvider services)
        {
            return new PortfolioViewModel(
                services.GetRequiredService<IDataService<Account>>(),
                services.GetRequiredService<IAccountStore>(),
                services.GetRequiredService<IPasswordHasher>(),
                services.GetRequiredService<ISnackbarService>(),
                services.GetRequiredService<IAuthenticator>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>()
            );
        }
       
        private static AssetsQueueViewModel CreateAssetsQueueViewModel(IServiceProvider services)
        {
            return AssetsQueueViewModel.LoadStockViewModel(
                services.GetRequiredService<IDataService<AssetQueue>>(),
                services.GetRequiredService<IDataService<Account>>(),
                services.GetRequiredService<IAccountStore>(),
                services.GetRequiredService<IStockPriceService>(),
                services.GetRequiredService<ISnackbarService>()
            );
        }
        private static AdminStocksViewModel CreateAdminStocksViewModel(IServiceProvider services)
        {
            return AdminStocksViewModel.LoadAdminStocksViewModel(services
                .GetRequiredService<IDataService<StockDescription>>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<CreateStockViewModel>>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<UpdateStockViewModel>>(),
                services.GetRequiredService<UpdateStockStore>(),
                services.GetRequiredService<ISnackbarService>(),
                services.GetRequiredService<IDataService<AssetTransaction>>(),
                services.GetRequiredService<IContentDialogService>()
                );
        }

        private static UpdateStockViewModel CreateUpdateStockViewModel(IServiceProvider services)
        {
            return UpdateStockViewModel.LoadUpdateStockViewModel(
                services.GetRequiredService<IDataService<StockDescription>>(),
                services.GetRequiredService<UpdateStockStore>(),
                services.GetRequiredService<ISnackbarService>()
            );
        }

        private static StockViewModel CreateStockViewModel(IServiceProvider services)
        {
            return StockViewModel.LoadStockViewModel(services.GetRequiredService<IStockDescriptionService>(),
                services.GetRequiredService<StockStore>(),
                services.GetRequiredService<IBuyStockService>(),
                services.GetRequiredService<IAccountStore>(),
                services.GetRequiredService<IStockDescriptionDataService>(),
                services.GetRequiredService<ISnackbarService>()
                );
        }
        
        private static UserViewModel CreateUserViewModel(IServiceProvider services)
        {
            return UserViewModel.LoadUserViewModel(
                services.GetRequiredService<IDataService<Account>>(),
                services.GetRequiredService<UsersStore>(),
                services.GetRequiredService<IDataService<StockDescription>>(),
                services.GetRequiredService<IContentDialogService>(),
                services.GetRequiredService<ISnackbarService>()
            );
        }

        private static UsersViewModel CreateUsersViewModel(IServiceProvider services)
        {
            return UsersViewModel.LoadUsersViewModel(services.GetRequiredService<IDataService<Account>>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<UserViewModel>>(),
                services.GetRequiredService<UsersStore>()
                );
        }
        
        private static BuyViewModel CreateBuyViewModel(IServiceProvider services)
        {
            return BuyViewModel.LoadBuyViewModel(services.GetRequiredService<IStockPriceService>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<StockViewModel>>(),
                services.GetRequiredService<StockStore>(),
                services.GetRequiredService<IDataService<StockDescription>>(),
                services.GetRequiredService<IContentDialogService>()
                );
        }

        private static HomeViewModel CreateHomeViewModel(IServiceProvider services)
        {
            return new HomeViewModel(
                services.GetRequiredService<AssetSummaryViewModel>(),
                MajorIndexListingViewModel.LoadMajorIndexViewModel(services.GetRequiredService<IMajorIndexService>()));
        }

        private static LoginViewModel CreateLoginViewModel(IServiceProvider services)
        { 
            return new LoginViewModel(
                services.GetRequiredService<IAuthenticator>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<HomeViewModel>>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<RegisterViewModel>>());
        }

        private static RegisterViewModel CreateRegisterViewModel(IServiceProvider services)
        {
            return new RegisterViewModel(
                services.GetRequiredService<IAuthenticator>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>());
        }
    }
}
