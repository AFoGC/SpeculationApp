using SpeculationApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Domain.Repositories
{
    public interface IPairRepository
    {
        IEnumerable<Pair> GetAll();
        void Update(Pair entity);
    }
}
