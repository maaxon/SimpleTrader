using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.WPF.Commands;
using System.Windows.Input;

namespace SimpleTrader.WPF.ViewModels
{
    public class MajorIndexListingViewModel : ViewModelBase
    {
        private MajorIndex _dowJones = new MajorIndex(){IndexName = "Dow Jones",Changes = -3.52,Price = 150030.43,Type = MajorIndexType.DowJones};
        public MajorIndex DowJones
        {
            get
            {
                return _dowJones;
            }
            set
            {
                _dowJones = value;
                OnPropertyChanged(nameof(DowJones));
            }
        }

        private MajorIndex _nasdaq = new MajorIndex(){IndexName = "Nasdaq",Changes = 4.38,Price = 247330.43,Type = MajorIndexType.Nasdaq};
        public MajorIndex Nasdaq
        {
            get
            {
                return _nasdaq;
            }
            set
            {
                _nasdaq = value;
                OnPropertyChanged(nameof(Nasdaq));
            }
        }

        private MajorIndex _sp500 =new MajorIndex(){IndexName = "S&P 500",Changes = -2.23,Price = 142030.04,Type = MajorIndexType.SP500};
        public MajorIndex SP500
        {
            get
            {
                return _sp500;
            }
            set
            {
                _sp500 = value;
                OnPropertyChanged(nameof(SP500));
            }
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        public ICommand LoadMajorIndexesCommand { get; }

        public MajorIndexListingViewModel(IMajorIndexService majorIndexService)
        {
            LoadMajorIndexesCommand = new LoadMajorIndexesCommand(this, majorIndexService);
        }

        public static MajorIndexListingViewModel LoadMajorIndexViewModel(IMajorIndexService majorIndexService)
        {
            MajorIndexListingViewModel majorIndexViewModel = new MajorIndexListingViewModel(majorIndexService);

            //majorIndexViewModel.LoadMajorIndexesCommand.Execute(null);

            return majorIndexViewModel;
        }
    }
}