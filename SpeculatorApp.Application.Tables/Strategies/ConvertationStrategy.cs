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
    public class ConvertationStrategy
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Func<ConvertationCollectionService> _getConvertations;

        public ConvertationStrategy(IUnitOfWork unitOfWork, MainCollectionService mainCollectionService)
        {
            _unitOfWork = unitOfWork;

            _getConvertations = () => mainCollectionService.ConvertationCollection;
        }

        public void Remove(ConvertationViewModel viewModel)
        {
            var convertations = _getConvertations.Invoke();
            convertations.Remove(viewModel);
        }

        public void Update(ConvertationEntity model)
        {
            _unitOfWork.Convertations.Update(model);
            _unitOfWork.Complete();
        }
    }
}
