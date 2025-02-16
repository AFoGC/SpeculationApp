using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Dal.Entities
{
    public class Pair : Entity
    {
        private int _baseCurrencyId;
        private int _tradeCurrencyId;
        private int _positionInList;

        private Currency _baseCurrency = null!;
        private Currency _tradeCurrency = null!;

        public Pair()
        {
            Convertations = new ObservableCollection<Convertation>();
        }

        public int BaseCurrencyId
        {
            get => _baseCurrencyId;
            set { _baseCurrencyId = value;  }
        }
        public int TradeCurrencyId
        {
            get => _tradeCurrencyId;
            set { _tradeCurrencyId = value; OnPropertyChanged(); }
        }
        public int PositionInList
        {
            get => _positionInList;
            set { _positionInList = value; OnPropertyChanged(); }
        }

        public Currency BaseCurrency
        {
            get => _baseCurrency;
            set { _baseCurrency = value; OnPropertyChanged(); }
        }
        public Currency TradeCurrency
        {
            get => _tradeCurrency;
            set { _tradeCurrency = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Convertation> Convertations { get; }
    }
}
