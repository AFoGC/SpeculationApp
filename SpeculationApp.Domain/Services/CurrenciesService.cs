using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Models;
using SpeculationApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Domain.Services
{
    public class CurrenciesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CurrenciesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<CurrencyModel> Load()
        {
            List<CurrencyModel> currencies = new List<CurrencyModel>();
            var entities = _unitOfWork.Currencies.GetAll();

            foreach (var entity in entities)
            {
                var operations = _unitOfWork.Operations.GetAll(entity.Id);
                CurrencyModel model = new CurrencyModel(entity, operations);

                currencies.Add(model);
            }

            return currencies;
        }
    }
}
