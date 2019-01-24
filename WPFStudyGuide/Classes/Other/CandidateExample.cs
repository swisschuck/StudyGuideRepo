using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WPFStudyGuide.Enums.Other;

namespace WPFStudyGuide.Classes.Other
{
    public class CandidateExample
    {
        #region fields

        private string _title;
        private string _name;
        private bool _wasRelected;
        private PartyAffiliation _party;

        #endregion fields


        #region properties

        public event PropertyChangedEventHandler PropertyChanged;

        public bool WasRelected
        {
            get { return _wasRelected; }
            set
            {
                _wasRelected = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        public PartyAffiliation Party
        {
            get { return _party; }
            set
            {
                _party = value;
                OnPropertyChanged();
            }
        }

        #endregion properties


        #region constructors
        #endregion constructors


        #region public methods

        public static ObservableCollection<CandidateExample> GetCandidates()
        {
            ObservableCollection<CandidateExample> employees = new ObservableCollection<CandidateExample>();

            employees.Add(new CandidateExample() { Name = "Candidate1", Title = "President 1", WasRelected = true, Party = PartyAffiliation.Democrat });
            employees.Add(new CandidateExample() { Name = "Candidate2", Title = "President 2", WasRelected = true, Party = PartyAffiliation.Federalist });
            employees.Add(new CandidateExample() { Name = "Candidate3", Title = "President 3", WasRelected = true, Party = PartyAffiliation.Independent });
            employees.Add(new CandidateExample() { Name = "Candidate4", Title = "President 4", WasRelected = true, Party = PartyAffiliation.Republican });
            employees.Add(new CandidateExample() { Name = "Candidate5", Title = "President 5", WasRelected = true, Party = PartyAffiliation.WhoGivesAShit });

            return employees;
        }

        #endregion public methods


        #region private methods

        private void OnPropertyChanged([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }

        #endregion private methods
    }
}
