using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Domain.Entities
{
    public interface IOperationType
    {
        int Id { get; set; }
        string Name { get; set; }
        bool IsIncrease { get; set; }
    }
}
