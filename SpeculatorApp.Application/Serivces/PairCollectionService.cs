using SpeculationApp.Domain.Repositories;
using SpeculatorApp.Application.Factories;
using SpeculatorApp.Application.MenuViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Serivces
{
    public class PairCollectionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PairViewModelFactory _factory;

        private ObservableCollection<PairViewModel>? _pairs;

        public PairCollectionService(IUnitOfWork unitOfWork, PairViewModelFactory factory)
        {
            _unitOfWork = unitOfWork;
            _factory = factory;
        }

        public ObservableCollection<PairViewModel> Pairs
        {
            get
            {
                if (_pairs == null)
                {
                    _pairs = new ObservableCollection<PairViewModel>();
                    var pairs = _unitOfWork.Pairs.GetAll();

                    foreach (var pair in pairs)
                    {
                        var viewModel = _factory.CreateViewModel(pair);
                        _pairs.Add(viewModel);
                    }
                }

                return _pairs;
            }
        }
    }
}
