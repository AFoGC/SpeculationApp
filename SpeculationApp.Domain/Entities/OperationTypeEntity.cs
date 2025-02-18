using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Domain.Entities
{
    public class OperationTypeEntity
    {
        public OperationTypeEntity()
        {
            Name = String.Empty;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsIncrease { get; set; }
    }
}
