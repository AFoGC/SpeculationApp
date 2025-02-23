using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SpeculationApp.Domain.Repositories;
using SpeculationApp.Infrastructure.Context;
using SpeculationApp.Infrastructure.Repositories;
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
            InitializeComponent();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            TradingContext tradingContext = new TradingContext();
            IUnitOfWork unitOfWork = new UnitOfWork(tradingContext);
            TablesService tablesService = new TablesService(unitOfWork);

            MenuStore menuStore = new MenuStore();
            NavigationService navigationService = new NavigationService(menuStore);

            MainMenuViewModel mainMenu = new MainMenuViewModel(navigationService, tablesService);
            navigationService.AddMenu(mainMenu);

            CurrencyMenuViewModel currencyMenu = new CurrencyMenuViewModel(navigationService);
            navigationService.AddMenu(currencyMenu);

            PairMenuViewModel pairMenu = new PairMenuViewModel(navigationService);
            navigationService.AddMenu(pairMenu);

            MainViewModel mainViewModel = new MainViewModel(menuStore);

            base.OnStartup(e);
        }


    }
}
