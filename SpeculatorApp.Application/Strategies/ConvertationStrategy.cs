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

        public void Update(CurrencyEntity model)
        {
            _unitOfWork.Currencies.Update(model);
            _unitOfWork.Complete();
        }
    }
}
