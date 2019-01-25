using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFStudyGuide.Commands.Other;
using WPFStudyGuide.Constants;
using WPFStudyGuide.ViewModels.Other;

namespace WPFStudyGuide.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region fields

        private BaseViewModel _currentViewModel;
        private CommandsExampleViewModel _commandsExampleViewModel;
        private AttachedPropertiesExampleViewModel _attachedPropertiesExampleViewModel;
        private PropertyChangeNotificationsExampleViewModel _propertyChangeNotificationsExampleViewModel;
        private ViewFirstExampleViewModel _viewFirstExampleViewModel;
        private ViewModelFirstExampleViewModel _viewModelFirstExampleViewModel;
        private ViewModelLocaterExampleViewModel _viewModelLocaterExampleViewModel;
        private ParentAndChildViewsExampleViewModel _parentAndChildViewsExampleViewModel;

        #endregion fields


        #region properties

        public BaseViewModel CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                SetProperty(ref _currentViewModel, value);
            }
        }


        public MyFirstRelayCommand<string> NavigationCommand
        {
            get;
            private set;
        }

        #endregion properties


        #region constructors

        public MainWindowViewModel()
        {
            //CurrentViewModel = _initialViewModel;
            NavigationCommand = new MyFirstRelayCommand<string>(OnNavigationClicked);
        }

        #endregion constructors


        #region public methods
        #endregion public methods


        #region private methods

        private void LoadWindowResources()
        {
            
        }

        private void OnNavigationClicked(string destination)
        {
            CurrentViewModel = null;

            switch (destination)
            {
                #region Examples

                case CommandParameters.LoadCommandsExample:
                    _commandsExampleViewModel = new CommandsExampleViewModel();
                    CurrentViewModel = _commandsExampleViewModel;
                    break;

                case CommandParameters.LoadAttachedPropertiesExample:
                    _attachedPropertiesExampleViewModel = new AttachedPropertiesExampleViewModel();
                    CurrentViewModel = _attachedPropertiesExampleViewModel;
                    break;

                case CommandParameters.LoadPropertyChangedExample:
                    _propertyChangeNotificationsExampleViewModel = new PropertyChangeNotificationsExampleViewModel();
                    CurrentViewModel = _propertyChangeNotificationsExampleViewModel;
                    break;

                case CommandParameters.LoadViewFirstExample:
                    _viewFirstExampleViewModel = new ViewFirstExampleViewModel();
                    CurrentViewModel = _viewFirstExampleViewModel;
                    break;

                case CommandParameters.LoadViewModelFirstExample:
                    _viewModelFirstExampleViewModel = new ViewModelFirstExampleViewModel();
                    CurrentViewModel = _viewModelFirstExampleViewModel;
                    break;

                case CommandParameters.LoadModelLocaterExample:
                    _viewModelLocaterExampleViewModel = new ViewModelLocaterExampleViewModel();
                    CurrentViewModel = _viewModelLocaterExampleViewModel;
                    break;

                case CommandParameters.LoadParentAndChildViewsExample:
                    _parentAndChildViewsExampleViewModel = new ParentAndChildViewsExampleViewModel();
                    CurrentViewModel = _parentAndChildViewsExampleViewModel;
                    break;

                    #endregion Examples
            }
        }

        #endregion private methods
    }
}
