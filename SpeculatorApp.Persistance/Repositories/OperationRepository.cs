using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Persistance.Repositories
{
    public class OperationRepository : IOperationRepository
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Operation> GetAll()
        {
            throw new NotImplementedException();
        }

        public Operation GetByid(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Operation entity)
        {
            throw new NotImplementedException();
        }
    }
}
