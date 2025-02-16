using SpeculationApp.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Dal.ViewEntity
{
    public class ConvertationViewEntity : Convertation
    {
        public decimal ExchangeRate
        {
            get
            {
                return BaseCurrencyAmount / TradeCurrencyAmount;
            }
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            switch (propertyName)
            {
                case nameof(BaseCurrencyAmount):
                    OnPropertyChanged(nameof(ExchangeRate));
                    break;

                case nameof(TradeCurrencyAmount):
                    OnPropertyChanged(nameof(ExchangeRate));
                    break;
            }

            base.OnPropertyChanged(propertyName);
        }
    }
}
