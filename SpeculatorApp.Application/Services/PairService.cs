using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using SpeculatorApp.Application.ViewModels.EditViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Services
{
    public class PairService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PairService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PairEditViewModel LoadPair(int baseCurrencyId, int tradeCurrencyId)
        {
            PairModel pairModel = _unitOfWork.Pairs.GetById(baseCurrencyId, tradeCurrencyId);
            CurrencyModel baseCurrency = _unitOfWork.Currencies.GetById(baseCurrencyId);
            CurrencyModel tradeCurrency = _unitOfWork.Currencies.GetById(tradeCurrencyId);

            var convertations = _unitOfWork.Convertations
                .GetAll(baseCurrencyId, tradeCurrencyId)
                .Select(x => CreateConvertation(x));

            return new PairEditViewModel(baseCurrency, tradeCurrency, convertations);
        }

        public ConvertationEditViewModel CreateConvertation(ConvertationModel model)
        {
            return new ConvertationEditViewModel(model);
        }
    }
}
