using SpeculatorApp.Application.Stores;
using SpeculatorApp.Application.Tables.ViewModels;
using SpeculatorApp.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Services
{
    public class NavigationService
    {
        private readonly List<ViewModel> _menus;
        private readonly MenuStore _menuStore;

        public NavigationService(MenuStore menuStore)
        {
            _menus = new List<ViewModel>();
            _menuStore = menuStore;
        }

        public bool AddMenu(ViewModel viewModel)
        {
            if (_menus.Contains(viewModel))
                return false;

            _menus.Add(viewModel);
            return true;
        }

        public T Navigate<T>() where T : ViewModel
        {
            var menu = _menus.Single(x => x.GetType() == typeof(T));
            _menuStore.CurrentMenu = menu;
            return (T)menu;
        }
    }
}
