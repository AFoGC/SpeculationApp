using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using SpeculatorApp.Application.MenuViewModels;
using SpeculatorApp.Application.Serivces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Strategies
{
    public class OperationTypeStrategy
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Func<OperationTypeCollectionService> _getOperationTypes;

        public OperationTypeStrategy(IUnitOfWork unitOfWork, MainCollectionService mainCollectionService)
        {
            _unitOfWork = unitOfWork;

            _getOperationTypes = () => mainCollectionService.OperationTypeCollection;
        }

        public void Remove(OperationTypeViewModel viewModel)
        {
            var operationTypes = _getOperationTypes.Invoke();
            operationTypes.Remove(viewModel);
        }

        public void Update(OperationTypeEntity model)
        {
            _unitOfWork.OperationTypes.Update(model);
            _unitOfWork.Complete();
        }
    }
}
