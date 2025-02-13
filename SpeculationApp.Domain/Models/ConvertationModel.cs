using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Domain.Models
{
    public class ConvertationModel
    {
        private readonly Convertation _entity;
        private readonly IUnitOfWork _unitOfWork;

        public ConvertationModel(Convertation entity, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _entity = entity;
        }

        public int Id
        {
            get => _entity.Id;
        }

        public int BaseCurrencyId
        {
            get => _entity.BaseCurrencyId;
            set
            {
                _entity.BaseCurrencyId = value;
                Update();
            }
        }

        public int TradeCurrencyId
        {
            get => _entity.TradeCurrencyId;
            set
            {
                _entity.TradeCurrencyId = value;
                Update();
            }
        }

        public decimal BaseCurrencyAmount
        {
            get => _entity.BaseCurrencyAmount; 
            set
            {
                _entity.BaseCurrencyAmount = value;
                Update();
            }
        }

        public decimal TradeCurrencyAmount
        {
            get => _entity.TradeCurrencyAmount; 
            set
            {
                _entity.TradeCurrencyAmount = value;
                Update();
            }
        }

        public bool ToTradeCurrency
        {
            get => _entity.ToTradeCurrency; 
            set
            {
                _entity.ToTradeCurrency = value;
                Update();
            }
        }

        public DateTime Date
        {
            get => _entity.Date; 
            set
            {
                _entity.Date = value;
                Update();
            }
        }

        private void Update()
        {
            _unitOfWork.Convertations.Update(_entity);
            _unitOfWork.Complete();
        }
    }
}
