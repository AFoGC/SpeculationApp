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
    public class OperationTypeCollectionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly OperationTypeViewModelFactory _factory;

        private ObservableCollection<OperationTypeViewModel>? _operationTypes;

        public OperationTypeCollectionService(IUnitOfWork unitOfWork, OperationTypeViewModelFactory factory)
        {
            _unitOfWork = unitOfWork;
            _factory = factory;
        }

        public ObservableCollection<OperationTypeViewModel> OperationTypes
        {
            get
            {
                if (_operationTypes == null)
                {
                    _operationTypes = new ObservableCollection<OperationTypeViewModel>();
                    var operationTypes = _unitOfWork.OperationTypes.GetAll();

                    foreach (var operationType in operationTypes)
                    {
                        var viewModel = _factory.CreateViewModel(operationType);
                        _operationTypes.Add(viewModel);
                    }
                }

                return _operationTypes;
            }
        }

        public void Remove(OperationTypeViewModel viewModel)
        {
            _unitOfWork.OperationTypes.Delete(viewModel.Id);
            _unitOfWork.Complete();

            OperationTypes.Remove(viewModel);
        }
    }
}
