using SpeculationApp.Application.Tables.ViewModels.EditViewModels;
using SpeculationApp.Application.Tables.ViewModels.ReadViewModel;
using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Application.Tables.Services
{
    public class CurrencyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CurrencyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CurrencyEditViewModel LoadCurrency(int currencyId, IEnumerable<OperationTypeReadViewModel> operationTypes)
        {
            CurrencyModel model = _unitOfWork.Currencies.GetById(currencyId);

            var operations = _unitOfWork.Operations
                .GetAll(currencyId)
                .Select(x => CreateOperation(x, operationTypes));

            return new CurrencyEditViewModel(model, operations);
        }

        public OperationEditViewModel CreateOperation(OperationModel model, IEnumerable<OperationTypeReadViewModel> operationTypes)
        {
            var type = operationTypes.Single(x => x.Id == model.Id);
            return new OperationEditViewModel(model, type);
        }
    }
}
