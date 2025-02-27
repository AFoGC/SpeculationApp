using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using SpeculatorApp.Application.ViewModels.EditViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Services
{
    public class MainMenuService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ObservableCollection<CurrencyReadViewModel> _currencies;
        private readonly ObservableCollection<PairReadViewModel> _pairs;

        public MainMenuService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            _currencies = new ObservableCollection<CurrencyReadViewModel>();
            _pairs = new ObservableCollection<PairReadViewModel>();
        }

        public ObservableCollection<CurrencyReadViewModel> Currencies => _currencies;
        public ObservableCollection<PairReadViewModel> Pairs => _pairs;

        public void LoadData()
        {
            _currencies.Clear();
            _pairs.Clear();

            IEnumerable<CurrencyModel> currencies = _unitOfWork.Currencies.GetAll();
            IEnumerable<PairModel> pairs = _unitOfWork.Pairs.GetAll();

            foreach (var currency in currencies)
            {
                _currencies.Add(CreateCurrency(currency));
            }

            foreach (var pair in pairs)
            {
                _pairs.Add(CreatePair(pair));
            }
        }

        private CurrencyReadViewModel CreateCurrency(CurrencyModel model)
        {
            return new CurrencyReadViewModel(_unitOfWork, model);
        }

        private PairReadViewModel CreatePair(PairModel model)
        {
            var baseCurrency = _currencies.Single(x => x.Id == model.BaseCurrencyId);
            var tradeCurrency = _currencies.Single(x => x.Id == model.TradeCurrencyId);

            return new PairReadViewModel(model, baseCurrency, tradeCurrency);
        }
    }
}
