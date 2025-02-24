using SpeculationApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Domain.Models
{
    public class PairModel
    {
        private readonly Entities.PairModel _entity;
        private readonly IEnumerable<ConvertationModel> _convertations;

        public PairModel(Entities.PairModel entity, IEnumerable<ConvertationModel> convertations)
        {
            _entity = entity;
            _convertations = convertations;
        }

        public Entities.PairModel PairEntity => _entity;
        public IEnumerable<ConvertationModel> Convertations => _convertations;
    }
}
