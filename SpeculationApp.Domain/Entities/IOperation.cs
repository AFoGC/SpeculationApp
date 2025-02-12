using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Domain.Entities
{
    public interface IOperation
    {
        int Id { get; set; }
        decimal Amount { get; set; }
        DateTime Date { get; set; }
        int OperationTypeId { get; set; }
    }
}
