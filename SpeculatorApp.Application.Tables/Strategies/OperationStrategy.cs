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
    public class OperationStrategy
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly Func<OperationCollectionService> _getOperations;
        private readonly Func<OperationTypeCollectionService> _getOperationTypes;

        public OperationStrategy(IUnitOfWork unitOfWork, MainCollectionService mainCollectionService)
        {
            _unitOfWork = unitOfWork;

            _getOperations = () => mainCollectionService.OperationCollection;
            _getOperationTypes = () => mainCollectionService.OperationTypeCollection;
        }

        public OperationTypeViewModel GetOperationType(int operationTypeId)
        {
            var operationTypes = _getOperationTypes.Invoke();
            return operationTypes.OperationTypes.Single(x => x.Id == operationTypeId);
        }

        public void Remove(OperationViewModel viewModel)
        {
            var operations = _getOperations.Invoke();
            operations.Remove(viewModel);
        }

        public void Update(OperationModel model)
        {
            _unitOfWork.Operations.Update(model);
            _unitOfWork.Complete();
        }
    }
}
