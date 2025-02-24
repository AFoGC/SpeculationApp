﻿using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using SpeculatorApp.Application.Tables.Factories;
using SpeculatorApp.Application.Tables.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Tables.Serivces
{
    public class CurrencyOperations
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly OperationViewModelFactory _factory;

        private readonly int _currencyId;
        private ObservableCollection<OperationViewModel>? _operations;

        public CurrencyOperations(IUnitOfWork unitOfWork, OperationViewModelFactory factory, int currencyId)
        {
            _unitOfWork = unitOfWork;
            _factory = factory;
            _currencyId = currencyId;
        }

        public int CurrencyId => _currencyId;

        public ObservableCollection<OperationViewModel> Operations
        {
            get
            {
                if (_operations == null)
                {
                    _operations = new ObservableCollection<OperationViewModel>();
                    var operations = _unitOfWork.Operations.GetAll(_currencyId);

                    foreach (var operation in operations)
                    {
                        var viewModel = _factory.CreateViewModel(operation);
                        _operations.Add(viewModel);
                    }
                }

                return _operations;
            }
        }

        public OperationViewModel AddOperation(OperationModel operation)
        {
            _unitOfWork.Operations.Create(operation);
            _unitOfWork.Complete();

            var viewModel = _factory.CreateViewModel(operation);
            Operations.Add(viewModel);

            return viewModel;
        }
    }

    public class OperationCollectionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly OperationViewModelFactory _factory;
        private readonly List<CurrencyOperations> _operations;

        public OperationCollectionService(IUnitOfWork unitOfWork, OperationViewModelFactory factory)
        {
            _unitOfWork = unitOfWork;
            _factory = factory;
            _operations= new List<CurrencyOperations>();
        }

        public CurrencyOperations GetOperations(int currencyId)
        {
            CurrencyOperations? operations = _operations
                .SingleOrDefault(x => x.CurrencyId == currencyId);

            if (operations == null)
            {
                //_unitOfWork.Currencies.GetById(currencyId);

                operations = new CurrencyOperations(_unitOfWork, _factory, currencyId);
                _operations.Add(operations);
            }

            return operations;
        }

        public void Remove(OperationViewModel viewModel)
        {
            _unitOfWork.Operations.Delete(viewModel.Id);
            _unitOfWork.Complete();

            var operations = GetOperations(viewModel.CurrencyId);
            operations.Operations.Remove(viewModel);
        }
    }
}
