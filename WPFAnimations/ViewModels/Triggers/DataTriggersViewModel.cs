using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFAnimations.Interfaces;

namespace WPFAnimations.ViewModels.Triggers
{
    public class DataTriggersViewModel : BaseViewModel, IViewModel
    {
        private DataObject _blah;


        public DataObject Blah
        {
            get
            {
                return _blah;
            }
            set
            {
                _blah = value;
                OnPropertyChanged(nameof(Blah));
            }
        }


        public string ViewModelNavName => "DataTriggersViewModel";

        public DataTriggersViewModel()
        {
            Blah = new DataObject();
        }
    }

    public class DataObject
    {
        public int TheValue { get; set; }
    }
}