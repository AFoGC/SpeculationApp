using SpeculationApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.ViewModels.EditViewModels
{
    public class OperationEditViewModel : ViewModel
    {
        private OperationModel _model;
        private bool _isChanged;

        private OperationTypeReadViewModel _operationType;
        private List<OperationTypeReadViewModel> _operationTypes;

        public OperationEditViewModel(OperationModel model, IEnumerable<OperationTypeReadViewModel> operationTypes)
        {
            _model = model;
            _operationTypes = operationTypes.ToList();

            var type = _operationTypes.Single(x => x.Id == _model.OperationTypeId);
            _operationType = type;
        }

        public bool IsChanged => _isChanged;

        public int Id => _model.Id;
        public int CurrencyId => _model.CurrencyId;
        public int OperationTypeId => _model.OperationTypeId;
        public decimal Amount
        {
            get => _model.Amount;
            set
            {
                _model.Amount = value;
                _isChanged = true;

                OnPropertyChanged();
            }
        }
        public DateTime Date
        {
            get => _model.Date;
            set
            {
                _model.Date = value;
                _isChanged = true;

                OnPropertyChanged();
            }
        }

        public OperationTypeReadViewModel OperationType
        {
            get => _operationType;
            set
            {
                _operationType = value;
                _model.OperationTypeId = value.Id;
                _isChanged = true;

                OnPropertyChanged();
            }
        }

        public IEnumerable<OperationTypeReadViewModel> OperationTypes => _operationTypes;

        public OperationModel GetModel()
        {
            return _model;
        }
    }
}
