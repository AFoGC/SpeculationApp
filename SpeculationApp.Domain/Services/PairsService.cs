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
    public class PairsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PairsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<PairModel> Load()
        {
            List<PairModel> pairs = new List<PairModel>();
            var entities = _unitOfWork.Pairs.GetAll();

            foreach (var entity in entities)
            {
                var convertations = _unitOfWork.Convertations.GetAll(entity.BaseCurrencyId, entity.TradeCurrencyId);
                PairModel model = new PairModel(entity, convertations);

                pairs.Add(model);
            }

            return pairs;
        }
    }
}
