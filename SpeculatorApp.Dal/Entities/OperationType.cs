using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Dal.Entities
{
    public class OperationType : Entity
    {
        private int _id;
        private string _name;
        private bool _isIncrease;

        public OperationType()
        {
            _name = String.Empty;

            Operations = new ObservableCollection<Operation>();
        }

        public int Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(); }
        }
        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }
        public bool IsIncrease
        {
            get => _isIncrease;
            set { _isIncrease = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Operation> Operations { get; }
    }
}
