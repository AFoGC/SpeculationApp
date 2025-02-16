using SpeculationApp.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Dal.ViewEntity
{
    public class PairViewEntity : Pair
    {
        public decimal GetBaseCurrencyAmount()
        {
            decimal output = 0;

            foreach (var item in Convertations)
            {
                if (item.ToTradeCurrency)
                {
                    output -= item.TradeCurrencyAmount;
                }
                else
                {
                    output += item.BaseCurrencyAmount;
                }
            }

            return output;
        }

        public decimal GetTradeCurrencyAmount()
        {
            decimal output = 0;

            foreach (var item in Convertations)
            {
                if (item.ToTradeCurrency)
                {
                    output += item.TradeCurrencyAmount;
                }
                else
                {
                    output -= item.BaseCurrencyAmount;
                }
            }

            return output;
        }
    }
}
