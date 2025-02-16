using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Dal.Entities
{
    public class Convertation : Entity
    {
        private int _id;
        private int _baseCurrencyId;
        private int _tradeCurrencyId;
        private decimal _baseCurrencyAmount;
        private decimal _tradeCurrencyAmount;
        private bool _toTradeCurrency;
        private DateTime _date;

        private Pair _pair = null!;

        public Convertation()
        {

        }

        public int Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(); }
        }
        public int BaseCurrencyId
        {
            get => _baseCurrencyId;
            set { _baseCurrencyId = value; OnPropertyChanged(); }
        }
        public int TradeCurrencyId
        {
            get => _tradeCurrencyId;
            set { _tradeCurrencyId = value; OnPropertyChanged(); }
        }
        public decimal BaseCurrencyAmount
        {
            get => _baseCurrencyAmount;
            set { _baseCurrencyAmount = value; OnPropertyChanged(); }
        }
        public decimal TradeCurrencyAmount
        {
            get => _tradeCurrencyAmount;
            set { _tradeCurrencyAmount = value; OnPropertyChanged(); }
        }
        public bool ToTradeCurrency
        {
            get => _toTradeCurrency;
            set { _toTradeCurrency = value; OnPropertyChanged(); }
        }
        public DateTime Date
        {
            get => _date;
            set { _date = value; OnPropertyChanged(); }
        }

        public Pair Pair
        {
            get => _pair;
            set { _pair = value; OnPropertyChanged(); }
        }
    }
}
