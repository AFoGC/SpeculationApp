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
        private readonly PairEntity _entity;
        private readonly IEnumerable<ConvertationEntity> _convertations;

        public PairModel(PairEntity entity, IEnumerable<ConvertationEntity> convertations)
        {
            _entity = entity;
            _convertations = convertations;
        }

        public PairEntity PairEntity => _entity;
        public IEnumerable<ConvertationEntity> Convertations => _convertations;
    }
}
