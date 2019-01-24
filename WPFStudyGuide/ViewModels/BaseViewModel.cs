using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFStudyGuide.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region fields
        #endregion fields


        #region properties

        public string ViewHeaderTitle { get; set; }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        #endregion properties


        #region constructors

        public BaseViewModel()
        {

        }

        #endregion constructors


        #region public methods

        protected virtual void SetProperty<T>(ref T member, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(member, value))
            {
                return;
            }

            member = value;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion public methods


        #region private methods
        #endregion private methods
    }
}
