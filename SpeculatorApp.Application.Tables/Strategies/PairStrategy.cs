using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using SpeculatorApp.Application.Tables.ViewModels;
using SpeculatorApp.Application.Tables.Serivces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Tables.Strategies
{
    public class PairStrategy
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Func<PairCollectionService> _getPairs;
        private readonly Func<CurrencyCollectionService> _getCurrencies;
        private readonly Func<ConvertationCollectionService> _getConvertations;

        private readonly int _baseCurrencyId;
        private readonly int _tradeCurrencyId;

        private PairConvertations? _pairConvertations;

        public PairStrategy(IUnitOfWork unitOfWork, MainCollectionService mainCollectionService, int baseCurrencyId, int tradeCurrencyId)
        {
            _unitOfWork = unitOfWork;

            _getPairs = () => mainCollectionService.PairCollection;
            _getCurrencies = () => mainCollectionService.CurrencyCollection;
            _getConvertations = () => mainCollectionService.ConvertationCollection;

            _baseCurrencyId = baseCurrencyId;
            _tradeCurrencyId = tradeCurrencyId;
        }

        public PairConvertations Convertations
        {
            get
            {
                if (_pairConvertations == null)
                {
                    var operations = _getConvertations.Invoke();
                    _pairConvertations = operations.GetConvertations(_baseCurrencyId, _tradeCurrencyId);
                }

                return _pairConvertations;
            }
        }

        public CurrencyViewModel GetCurrency(int currencyId)
        {
            var currencies = _getCurrencies.Invoke();
            return currencies.Currencies.Single(x => x.Id == currencyId);
        }

        public void Remove(PairViewModel viewModel)
        {
            var pairs = _getPairs.Invoke();
            pairs.Remove(viewModel);
        }

        public void Update(PairEntity model)
        {
            _unitOfWork.Pairs.Update(model);
            _unitOfWork.Complete();
        }
    }
}
