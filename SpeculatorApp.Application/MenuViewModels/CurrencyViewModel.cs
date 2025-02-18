using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using SpeculatorApp.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.MenuViewModels
{
    public class CurrencyViewModel : ViewModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CurrencyEntity _currency;

        private ObservableCollection<OperationViewModel>? _operations;

        public CurrencyViewModel(IUnitOfWork unitOfWork, CurrencyEntity currency)
        {
            _unitOfWork = unitOfWork;
            _currency = currency;
        }

        public int Id => _currency.Id;
        public string Code
        {
            get => _currency.Code;
            set { _currency.Code = value; OnPropertyChanged(); }
        }
        public string Name
        {
            get => _currency.Name;
            set { _currency.Name = value; OnPropertyChanged(); }
        }
        public decimal TotalAmount
        {
            get => 0;
        }

        public IEnumerable<OperationViewModel> Operations
        {
            get
            {
                if (_operations == null)
                {
                    _operations = new ObservableCollection<OperationViewModel>();

                    var entities = _unitOfWork.Operations.GetAll(_currency.Id);

                    foreach (var entity in entities)
                    {
                        var viewModel = new OperationViewModel(entity);
                        _operations.Add(viewModel);
                    }
                }

                return _operations;
            }
        }
    }
}
