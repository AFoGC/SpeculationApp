﻿using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SpeculationApp.Dal.Context;
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
            string connectionString = "Datasource=" + "C:\\Users\\sirko\\source\\repos\\SpeculationApp\\SpeculationApp.Wpf\\bin\\Debug\\net7.0-windows\\Films.db";
            SqliteConnection connection = new SqliteConnection(connectionString);

            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
            var opt = optionsBuilder.UseSqlite(connection).Options;
            TradingContext filmsContext = new TradingContext(opt);

            filmsContext.Database.EnsureCreated();
            filmsContext.SaveChanges();
        }


    }
}
