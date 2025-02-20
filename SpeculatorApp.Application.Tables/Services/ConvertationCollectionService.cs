using SpeculationApp.Domain.Repositories;
using SpeculatorApp.Application.Tables.Factories;
using SpeculatorApp.Application.Tables.ViewModels;
using System.Collections.ObjectModel;

namespace SpeculatorApp.Application.Tables.Serivces
{
    public class PairConvertations
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ConvertationViewModelFactory _factory;

        private readonly int _baseCurrencyId;
        private readonly int _tradeCurrencyId;
        private ObservableCollection<ConvertationViewModel>? _convertations;

        public PairConvertations(IUnitOfWork unitOfWork, ConvertationViewModelFactory factory, int baseCurrencyId, int tradeCurrencyId)
        {
            _unitOfWork = unitOfWork;
            _factory = factory;
            _baseCurrencyId = baseCurrencyId;
            _tradeCurrencyId = tradeCurrencyId;
        }

        public int BaseCurrencyId => _baseCurrencyId;
        public int TradeCurrencyId => _tradeCurrencyId;

        public ObservableCollection<ConvertationViewModel> Convertations
        {
            get
            {
                if (_convertations == null)
                {
                    _convertations = new ObservableCollection<ConvertationViewModel>();
                    var convertations = _unitOfWork.Convertations.GetAll(_baseCurrencyId, _tradeCurrencyId);

                    foreach (var convertation in convertations)
                    {
                        var viewModel = _factory.CreateViewModel(convertation);
                        _convertations.Add(viewModel);
                    }
                }

                return _convertations;
            }
        }
    }

    public class ConvertationCollectionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ConvertationViewModelFactory _factory;

        private List<PairConvertations> _convertations;

        public ConvertationCollectionService(IUnitOfWork unitOfWork, ConvertationViewModelFactory factory)
        {
            _unitOfWork = unitOfWork;
            _factory = factory;

            _convertations = new List<PairConvertations>();
        }

        public PairConvertations GetConvertations(int baseCurrencyId, int tradeCurrencyId)
        {
            PairConvertations? operations = _convertations
                .SingleOrDefault(x => x.BaseCurrencyId == baseCurrencyId && x.TradeCurrencyId == tradeCurrencyId);

            if (operations == null)
            {
                //_unitOfWork.Pairs.GetById(baseCurrencyId, tradeCurrencyId);

                operations = new PairConvertations(_unitOfWork, _factory, baseCurrencyId, tradeCurrencyId);
                _convertations.Add(operations);
            }

            return operations;
        }

        public void Remove(ConvertationViewModel viewModel)
        {
            _unitOfWork.Convertations.Delete(viewModel.Id);
            _unitOfWork.Complete();

            var operations = GetConvertations(viewModel.BaseCurrencyId, viewModel.TradeCurrencyId);
            operations.Convertations.Remove(viewModel);
        }
    }
}
