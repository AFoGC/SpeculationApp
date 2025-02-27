using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SpeculationApp.Domain.Repositories;
using SpeculationApp.Infrastructure.Context;
using SpeculationApp.Infrastructure.Repositories;
using SpeculationApp.Wpf.Windows;
using SpeculatorApp.Application.Services;
using SpeculatorApp.Application.Stores;
using SpeculatorApp.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SpeculationApp.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            //InitializeComponent();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            string connectionString = "Datasource=C:\\Users\\sirko\\source\\repos\\SpeculationApp\\SpeculationApp.Wpf\\bin\\Debug\\net7.0-windows\\Films.db";
            SqliteConnection connection = new SqliteConnection(connectionString);

            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
            var opt = optionsBuilder.UseSqlite(connection).Options;
            TradingContext tradingContext = new TradingContext(opt);
            tradingContext.Database.Migrate();

            IUnitOfWork unitOfWork = new UnitOfWork(tradingContext);
            MainMenuService mainMenuService = new MainMenuService(unitOfWork);
            CurrencyService currencyService = new CurrencyService(unitOfWork);
            PairService pairService = new PairService(unitOfWork);

            MenuStore menuStore = new MenuStore();
            NavigationService navigationService = new NavigationService(menuStore);

            MainMenuViewModel mainMenu = new MainMenuViewModel(navigationService, mainMenuService);
            navigationService.AddMenu(mainMenu);

            CurrencyMenuViewModel currencyMenu = new CurrencyMenuViewModel(navigationService, currencyService);
            navigationService.AddMenu(currencyMenu);

            PairMenuViewModel pairMenu = new PairMenuViewModel(navigationService, pairService);
            navigationService.AddMenu(pairMenu);

            MainViewModel mainViewModel = new MainViewModel(menuStore);

            MainWindow = new MainWindow()
            {
                DataContext = mainViewModel
            };

            mainMenu.LoadData();
            navigationService.Navigate<MainMenuViewModel>();

            MainWindow.Show();
            base.OnStartup(e);
        }


    }
}
