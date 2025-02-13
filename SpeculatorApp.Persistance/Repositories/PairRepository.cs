using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Persistance.Repositories
{
    public class PairRepository : IPairRepository
    {
        public IEnumerable<Pair> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Pair entity)
        {
            throw new NotImplementedException();
        }
    }
}
