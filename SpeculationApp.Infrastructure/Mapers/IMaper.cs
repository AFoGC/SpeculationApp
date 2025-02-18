using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Infrastructure.Mapers
{
    public interface IMaper<TEntity, TDomainEntity>
    {
        TDomainEntity MapEntity(TEntity entity);
        TEntity MapDomainEntity(TDomainEntity entity); 
    }
}
