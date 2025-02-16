using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Dal.Entities
{
    public class Operation : Entity
    {
        private int _id;
        private int _operationTypeId;
        private int _currencyId;
        private decimal _amount;
        private DateTime _date;

        private OperationType _operationType = null!;
        private Currency _currency = null!;

        public Operation()
        {

        }

        public int Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(); }
        }
        public int OperationTypeId
        {
            get => _operationTypeId;
            set { _operationTypeId = value; OnPropertyChanged(); }
        }
        public int CurrencyId
        {
            get => _currencyId;
            set { _currencyId = value; OnPropertyChanged(); }
        }
        public decimal Amount
        {
            get => _amount;
            set { _amount = value; OnPropertyChanged(); }
        }
        public DateTime Date
        {
            get => _date;
            set { _date = value; OnPropertyChanged(); }
        }

        public OperationType OperationType
        {
            get => _operationType;
            set { _operationType = value; OnPropertyChanged(); }
        }
        public Currency Currency
        {
            get => _currency;
            set { _currency = value; OnPropertyChanged(); }
        }
    }
}
