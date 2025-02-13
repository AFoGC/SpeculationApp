using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Domain.Services
{
    public class CurrencyDomainService
    {
        private readonly Currency _currency;

        public CurrencyDomainService(Currency currency)
        {
            _currency = currency;
        }

        public decimal CalculateCurrencyCount(IUnitOfWork unitOfWork)
        {


            return 0;
        }

        private decimal GetCountAsBaseCurrency(IConvertationRepository repository)
        {
            decimal total = 0;
            var currencyConvertations = convertations.Where(x => x.BaseCurrencyId == _currency.Id);

            foreach (var convertation in currencyConvertations)
            {
                if (convertation.ToTradeCurrency)
                {
                    total -= convertation.BaseCurrencyAmount;
                }
                else
                {
                    total += convertation.BaseCurrencyAmount;
                }
            }

            return total;
        }

        private decimal GetCountAsTradeCurrency(IConvertationRepository repository)
        {
            decimal total = 0;
            var currencyConvertations = convertations.Where(x => x.TradeCurrencyId == _currency.Id);

            foreach (var convertation in currencyConvertations)
            {
                if (convertation.ToTradeCurrency)
                {
                    total += convertation.TradeCurrencyAmount;
                }
                else
                {
                    total -= convertation.TradeCurrencyAmount;
                }
            }

            return total;
        }

        private decimal GetCountFromOperations(IEnumerable<Operation> operations)
        {
            decimal total = 0;

            /*
            foreach (var operation in currency.Operations)
            {
                if (operation.OperationType.IsPositive)
                {
                    total += operation.Amount;
                }
                else
                {
                    total -= operation.Amount;
                }
            }
            */
            return total;
        }
    }
}
