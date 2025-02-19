﻿using SpeculationApp.Domain.Entities;
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

        public void Update(CurrencyEntity model)
        {
            _unitOfWork.Currencies.Update(model);
            _unitOfWork.Complete();
        }
    }
}
