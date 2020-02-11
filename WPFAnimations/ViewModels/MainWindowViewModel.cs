using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFAnimations.Commands;
using WPFAnimations.Interfaces;
using WPFAnimations.Navigation;
using WPFAnimations.ViewModels.Animations;
using WPFAnimations.ViewModels.Triggers;

namespace WPFAnimations.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields
        private IViewModel _currentPageViewModel;
        private List<IViewModel> _pageViewModels;

        #endregion Fields


        #region Properties

        public List<IViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                {
                    _pageViewModels = new List<IViewModel>();
                }

                return _pageViewModels;
            }
        }

        public IViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                if (_currentPageViewModel != value)
                {
                    _currentPageViewModel = value;
                    OnPropertyChanged(nameof(CurrentPageViewModel));
                }
            }
        }

        #endregion Properties


        #region Commands

        public MyRelayCommand NavigateToHomeCommand { get; private set; }

        public MyRelayCommand NavigateToSingleTriggersCommand { get; private set; }

        public MyRelayCommand NavigateToMultiTriggersCommand { get; private set; }

        public MyRelayCommand NavigateToEventTriggersCommand { get; private set; }

        public MyRelayCommand NavigateToDataTriggersCommand { get; private set; }

        public MyRelayCommand NavigateToMultiDataTriggersCommand { get; private set; }

        public MyRelayCommand NavigateToBasicAnimationsCommand { get; private set; }

        public MyRelayCommand NavigateToEasingAnimationsCommand { get; private set; }

        public MyRelayCommand NavigateToKeyFrameAnimationsCommand { get; private set; }

        public MyRelayCommand NavigateToPathAnimationsCommand { get; private set; }
        #endregion Commands


        #region Constructors
        public MainWindowViewModel()
        {
            // Register Message objects
            //Messenger.Default.Register<BusyMessage>(this, (m) =>
            //{
            //    ApplicationIsBusy = m.IsBusy;
            //});

            //Messenger.Default.Register<QuickGlanceMessage>(this, (m) =>
            //{
            //    QuickGlanceMessageText = m.QuickGlanceText;
            //});

            //Messenger.Default.Register<QuickGlanceStatsMessage>(this, (m) =>
            //{
            //    GlanceStats = m.Stats;
            //});

            // add all view models to list
            PageViewModels.Add(new HomeViewModel());
            PageViewModels.Add(new SingleTriggersViewModel());
            PageViewModels.Add(new MultiTriggerViewModel());
            PageViewModels.Add(new EventTriggersViewModel());
            PageViewModels.Add(new DataTriggersViewModel());
            PageViewModels.Add(new MultiDataTriggersViewModel());
            PageViewModels.Add(new BasicAnimationsViewModel());
            PageViewModels.Add(new EasingAnimationsViewModel());
            PageViewModels.Add(new KeyFrameAnimationsViewModel());
            PageViewModels.Add(new PathAnimationsViewModel());

            // add all navigation methods to the mediator so views can navigate if they want
            //NavigationMediator.Subscribe("OnNavigateToHome", OnNavigateToHome);
            //NavigationMediator.Subscribe("OnNavigateToSingleTriggers", OnNavigateToSingleTriggers);
            //NavigationMediator.Subscribe("OnNavigateToEventTriggers", OnNavigateToEventTriggers);

            // wire up all commands for the main window
            NavigateToHomeCommand = new MyRelayCommand(OnNavigateToHome);
            NavigateToSingleTriggersCommand = new MyRelayCommand(OnNavigateToSingleTriggers);
            NavigateToMultiTriggersCommand = new MyRelayCommand(OnNavigateToMultiTriggers);
            NavigateToEventTriggersCommand = new MyRelayCommand(OnNavigateToEventTriggers);
            NavigateToDataTriggersCommand = new MyRelayCommand(OnNavigateToDataTriggers);
            NavigateToMultiDataTriggersCommand = new MyRelayCommand(OnNavigateToMultiDataTriggers);
            NavigateToBasicAnimationsCommand = new MyRelayCommand(OnNavigateToBasicAnimations);
            NavigateToEasingAnimationsCommand = new MyRelayCommand(OnNavigateToEasingAnimations);
            NavigateToKeyFrameAnimationsCommand = new MyRelayCommand(OnNavigateToKeyFrameAnimations);
            NavigateToPathAnimationsCommand = new MyRelayCommand(OnNavigateToPathAnimations);

            //load up our starting view
            CurrentPageViewModel = PageViewModels.Where(vm => vm.ViewModelNavName == typeof(HomeViewModel).Name).FirstOrDefault();
        }

        #endregion Constructors


        #region Private Methods

        private void ChangeViewModel(IViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
            {
                PageViewModels.Add(viewModel);
            }

            CurrentPageViewModel = PageViewModels.FirstOrDefault(vm => vm == viewModel);
        }

        private void OnNavigateToHome(object obj)
        {
            IViewModel modelToLoad = PageViewModels.Where(vm => vm.ViewModelNavName == typeof(HomeViewModel).Name).FirstOrDefault();
            ChangeViewModel(modelToLoad);
        }

        private void OnNavigateToSingleTriggers(object obj)
        {
            IViewModel modelToLoad = PageViewModels.Where(vm => vm.ViewModelNavName == typeof(SingleTriggersViewModel).Name).FirstOrDefault();
            ChangeViewModel(modelToLoad);
        }

        private void OnNavigateToMultiTriggers(object obj)
        {
            IViewModel modelToLoad = PageViewModels.Where(vm => vm.ViewModelNavName == typeof(MultiTriggerViewModel).Name).FirstOrDefault();
            ChangeViewModel(modelToLoad);
        }

        private void OnNavigateToEventTriggers(object obj)
        {
            IViewModel modelToLoad = PageViewModels.Where(vm => vm.ViewModelNavName == typeof(EventTriggersViewModel).Name).FirstOrDefault();
            ChangeViewModel(modelToLoad);
        }

        private void OnNavigateToDataTriggers(object obj)
        {
            IViewModel modelToLoad = PageViewModels.Where(vm => vm.ViewModelNavName == typeof(DataTriggersViewModel).Name).FirstOrDefault();
            ChangeViewModel(modelToLoad);
        }

        private void OnNavigateToMultiDataTriggers(object obj)
        {
            IViewModel modelToLoad = PageViewModels.Where(vm => vm.ViewModelNavName == typeof(MultiDataTriggersViewModel).Name).FirstOrDefault();
            ChangeViewModel(modelToLoad);
        }

        private void OnNavigateToBasicAnimations(object obj)
        {
            IViewModel modelToLoad = PageViewModels.Where(vm => vm.ViewModelNavName == typeof(BasicAnimationsViewModel).Name).FirstOrDefault();
            ChangeViewModel(modelToLoad);
        }

        private void OnNavigateToEasingAnimations(object obj)
        {
            IViewModel modelToLoad = PageViewModels.Where(vm => vm.ViewModelNavName == typeof(EasingAnimationsViewModel).Name).FirstOrDefault();
            ChangeViewModel(modelToLoad);
        }

        private void OnNavigateToKeyFrameAnimations(object obj)
        {
            IViewModel modelToLoad = PageViewModels.Where(vm => vm.ViewModelNavName == typeof(KeyFrameAnimationsViewModel).Name).FirstOrDefault();
            ChangeViewModel(modelToLoad);
        }

        private void OnNavigateToPathAnimations(object obj)
        {
            IViewModel modelToLoad = PageViewModels.Where(vm => vm.ViewModelNavName == typeof(PathAnimationsViewModel).Name).FirstOrDefault();
            ChangeViewModel(modelToLoad);
        }
        #endregion Private Methods

    }
}
