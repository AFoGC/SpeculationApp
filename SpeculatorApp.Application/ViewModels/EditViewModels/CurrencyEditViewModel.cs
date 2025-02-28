using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.ViewModels.EditViewModels
{
    public class CurrencyEditViewModel : ViewModel
    {
        private readonly ObservableCollection<OperationEditViewModel> _operations;

        private CurrencyModel _model;
        private bool _isChanged;

        public CurrencyEditViewModel(CurrencyModel model, IEnumerable<OperationEditViewModel> operations)
        {
            _operations = new ObservableCollection<OperationEditViewModel>(operations);

            _model = model;
        }

        public bool IsChanged => _isChanged;

        public int Id => _model.Id;
        public string Code
        {
            get => _model.Code;
            set
            {
                _model.Code = value;
                _isChanged = true;

                OnPropertyChanged();
            }
        }
        public string Name
        {
            get => _model.Name;
            set
            {
                _model.Name = value;
                _isChanged = true;

                OnPropertyChanged();
            }
        }

        public ObservableCollection<OperationEditViewModel> Operations => _operations;

        public CurrencyModel GetModel()
        {
            return _model;
        }
    }
}
