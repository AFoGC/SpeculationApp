using SpeculationApp.Domain.Repositories;
using SpeculatorApp.Application.Factories;
using SpeculatorApp.Application.MenuViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Serivces
{
    public class CurrencyCollectionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CurrencyViewModelFactory _factory;

        private ObservableCollection<CurrencyViewModel>? _currencies;

        public CurrencyCollectionService(IUnitOfWork unitOfWork, CurrencyViewModelFactory factory)
        {
            _unitOfWork = unitOfWork;
            _factory = factory;
        }

        public ObservableCollection<CurrencyViewModel> Currencies
        {
            get
            {
                if (_currencies == null)
                {
                    _currencies = new ObservableCollection<CurrencyViewModel>();
                    var currencies = _unitOfWork.Currencies.GetAll();

                    foreach (var currency in currencies)
                    {
                        var viewModel = _factory.CreateViewModel(currency);
                        _currencies.Add(viewModel);
                    }
                }

                return _currencies;
            }
        }
    }
}
