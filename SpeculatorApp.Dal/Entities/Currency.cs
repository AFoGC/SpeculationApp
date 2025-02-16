using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Dal.Entities
{
    public class Currency : Entity
    {
        private int _id;
        private string _code;
        private string _name;


        public Currency()
        {
            _code = String.Empty;
            _name = String.Empty;

            PairsAsBaseCurrency = new ObservableCollection<Pair>();
            PairsAsTradeCurrency = new ObservableCollection<Pair>();
            Operations = new ObservableCollection<Operation>();
        }

        public int Id
        {
            get => _id; 
            set { _id = value; OnPropertyChanged(); }
        }
        public string Code
        {
            get => _code;
            set { _code = value; OnPropertyChanged(); }
        }
        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Pair> PairsAsBaseCurrency { get; }
        public ObservableCollection<Pair> PairsAsTradeCurrency { get; }
        public ObservableCollection<Operation> Operations { get; } 
    }
}
