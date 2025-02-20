using SpeculationApp.Domain.Repositories;
using SpeculatorApp.Application.Tables.Serivces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Services
{
    public class TablesService
    {
        private readonly IUnitOfWork _unitOfWork;

        private MainCollectionService? _tables;

        public TablesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public MainCollectionService Tables
        {
            get
            {
                if (_tables == null)
                {
                    _tables = new MainCollectionService(_unitOfWork);
                }

                return _tables;
            }
        }
    }
}
