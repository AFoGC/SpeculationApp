﻿using SpeculationApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Domain.Repositories
{
    public interface IPairRepository
    {
        IEnumerable<PairEntity> GetAll();
        PairEntity GetById(int baseCurrencyId, int tradeCurrencyId);
        void Create(PairEntity entity);
        void Update(PairEntity entity);
        void Update(IEnumerable<PairEntity> entities);
        void Delete(int baseCurrencyId, int tradeCurrencyId);
    }
}
