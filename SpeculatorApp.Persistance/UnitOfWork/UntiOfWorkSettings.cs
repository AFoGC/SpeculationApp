using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Persistance.UnitOfWork
{
    public class UnitOfWorkSettings
    {
        public UnitOfWorkSettings()
        {
            Name = String.Empty;
        }

        public string Name { get; }
    }
}
