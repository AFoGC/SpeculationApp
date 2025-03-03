using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using SpeculatorApp.Application.Stores;
using SpeculatorApp.Application.ViewModels.EditViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Factories
{
    public class EditViewModelFactory
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ReadTablesStore _tablesStore;

        public EditViewModelFactory(ReadTablesStore tablesStore, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _tablesStore = tablesStore;
        }

        public CurrencyEditViewModel CreateCurrency(CurrencyModel model, IEnumerable<OperationEditViewModel> operations)
        {
            return new CurrencyEditViewModel(model, operations);
        }

        public OperationEditViewModel CreateOperation(OperationModel model, IEnumerable<OperationTypeReadViewModel> operationTypes)
        {
            return new OperationEditViewModel(model, operationTypes);
        }

        public PairEditViewModel CreatePair(CurrencyReadViewModel baseCurrency, CurrencyReadViewModel tradeCurrency, IEnumerable<ConvertationEditViewModel> convertations)
        {
            return new PairEditViewModel(baseCurrency, tradeCurrency, convertations);
        }

        public ConvertationEditViewModel CreateConvertation(ConvertationModel model)
        {
            return new ConvertationEditViewModel(model);
        }
    }
}
