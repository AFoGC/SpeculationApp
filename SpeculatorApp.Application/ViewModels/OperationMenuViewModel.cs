using SpeculationApp.Domain.Repositories;
using SpeculatorApp.Application.Commands;
using SpeculatorApp.Application.Services;
using SpeculatorApp.Application.Stores;
using SpeculatorApp.Application.ViewModels.EditViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpeculatorApp.Application.ViewModels
{
    public class OperationMenuViewModel : ViewModel
    {
        private readonly ReadTablesStore _tablesStore;
        private readonly NavigationService _navigation;
        private readonly IUnitOfWork _unitOfWork;

        private OperationEditViewModel? _operation;
        private CurrencyEditViewModel? _currency;

        private bool _isChanged;
        private int? _operationId;
        private int? _currencyId;
        private decimal? _amount;
        private DateTime? _date;
        private OperationTypeReadViewModel? _operationType;

        public OperationMenuViewModel(NavigationService navigation, ReadTablesStore tablesStore, IUnitOfWork unitOfWork)
        {
            _navigation = navigation;
            _tablesStore = tablesStore;
            _unitOfWork = unitOfWork;

            GoBackCommand = new RelayCommand(GoBack);
            UpdateOperationCommand = new RelayCommand(UpdateOperation);
        }

        public ICommand GoBackCommand { get; }
        public ICommand UpdateOperationCommand { get; }

        public IEnumerable<OperationTypeReadViewModel> OperationTypes => _tablesStore.OperationTypes;

        public CurrencyEditViewModel? Currency
        {
            get => _currency;
            set { _currency = value; OnPropertyChanged(); }
        }

        public OperationEditViewModel? Operation
        {
            get => _operation;
            set
            { 
                _operation = value;

                IsChanged = false;
                OperationId = _operation?.Id;
                CurrencyId = _operation?.CurrencyId;
                Amount = _operation?.Amount;
                Date = _operation?.Date;
                OperationType = _operation?.OperationType;

                OnPropertyChanged(); 
            }
        }

        public bool IsChanged
        {
            get => _isChanged;
            private set
            {
                _isChanged = value;
                OnPropertyChanged();
            }
        }

        public int? OperationId
        {
            get => _operationId;
            private set
            {
                _operationId = value;
                OnPropertyChanged();
                IsChanged = true;
            }
        }
        public int? CurrencyId
        {
            get => _currencyId;
            private set
            {
                _currencyId = value;
                OnPropertyChanged();
                IsChanged = true;
            }
        }
        public decimal? Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                OnPropertyChanged();
                IsChanged = true;
            }
        }
        public DateTime? Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged();
                IsChanged = true;
            }
        }
        public OperationTypeReadViewModel? OperationType
        {
            get => _operationType;
            set
            {
                _operationType = value;
                OnPropertyChanged();
                IsChanged = true;
            }
        }

        public void GoBack(object? obj)
        {
            _navigation.Navigate<CurrencyMenuViewModel>();
        }

        public void UpdateOperation(object? obj)
        {
            if (OperationType == null || Amount == null || Date == null || Operation == null)
                throw new NullReferenceException();

            if (IsChanged)
            {
                if (Operation.OperationType != OperationType)
                    Operation.OperationType = OperationType;

                if (Operation.Amount != Amount)
                    Operation.Amount = (decimal)Amount;

                if (Operation.Date != Date)
                    Operation.Date = (DateTime)Date;

                var model = Operation.GetModel();
                _unitOfWork.Operations.Update(model);
                _tablesStore.RefreshCurrency(model.CurrencyId);
            }

            _navigation.Navigate<CurrencyMenuViewModel>();
        }
    }
}
