using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WPFStudyGuide.Enums.Other;

namespace WPFStudyGuide.Classes.Other
{
    public class Candidate
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

        public static ObservableCollection<Candidate> GetCandidates()
        {
            ObservableCollection<Candidate> employees = new ObservableCollection<Candidate>();

            employees.Add(new Candidate() { Name = "Candidate1", Title = "President 1", WasRelected = true, Party = PartyAffiliation.Democrat });
            employees.Add(new Candidate() { Name = "Candidate2", Title = "President 2", WasRelected = true, Party = PartyAffiliation.Federalist });
            employees.Add(new Candidate() { Name = "Candidate3", Title = "President 3", WasRelected = true, Party = PartyAffiliation.Independent });
            employees.Add(new Candidate() { Name = "Candidate4", Title = "President 4", WasRelected = true, Party = PartyAffiliation.Republican });
            employees.Add(new Candidate() { Name = "Candidate5", Title = "President 5", WasRelected = true, Party = PartyAffiliation.WhoGivesAShit });

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
