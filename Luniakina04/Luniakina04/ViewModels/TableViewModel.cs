using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;
using Luniakina04.Models;
using Luniakina04.Tools;
using Luniakina04.Tools.Managers;
using Luniakina04.Tools.Navigation;


namespace Luniakina04.ViewModels
{
    internal class TableViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public TableViewModel()
        {
            StationManager.TablePersonVM = this;
        }

        #region Fields

        private List<Person> _personList = StationManager.DataStorage.PersonsList;
        private string[] _sortCases =
        {
            "Name",
            "Surname",
            "Email",
            "Birth date",
            "Sun sign",
            "Chinese sign"
        };
        private string[] _filterCases =
        {
            "Name",
            "Surname",
            "Email",
            "Sun sign",
            "Chinese sign"
        };

        private RelayCommand<object> _addPersonCommand;
        private RelayCommand<object> _editPersonCommand;
        private RelayCommand<object> _removePersonCommand;
        private RelayCommand<object> _filterCommand;

        private int _sortCase = 0;
        private int _filterCase = 0;

        #endregion

        #region Properties

        public string FilterLetters { get; set; }

        public int Sort
        {
            get { return _sortCase; }
            set
            {
                _sortCase = value;
                OnPropertyChanged("PersonList");
            }
        }

        public int Filter
        {
            get { return _filterCase; }
            set
            {
                _filterCase = value;
                OnPropertyChanged("PersonList");
            }
        }


        public object SelectedPerson { get; set; }

        public IEnumerable<Person> PersonList
        {
            get
            {
                IEnumerable<Person> peopleList = _personList;

                switch (Sort)
                {
                    case 0:
                        peopleList = peopleList.OrderBy(x => x.Name);
                        break;
                    case 1:
                        peopleList = peopleList.OrderBy(x => x.Surname);
                        break;
                    case 2:
                        peopleList = peopleList.OrderBy(x => x.Email);
                        break;
                    case 3:
                        peopleList = peopleList.OrderBy(x => x.Birthday);
                        break;
                    case 4:
                        peopleList = peopleList.OrderBy(x => x.SunSign);
                        break;
                    case 5:
                        peopleList = peopleList.OrderBy(x => x.ChineseSign);
                        break;
                }

                if (String.IsNullOrWhiteSpace(FilterLetters))
                    return peopleList;

                switch (Filter)
                {
                    case 0:
                        peopleList = peopleList.Where(x => x.Name.Contains(FilterLetters));
                        break;
                    case 1:
                        peopleList = peopleList.Where(x => x.Surname.Contains(FilterLetters));
                        break;
                    case 2:
                        peopleList = peopleList.Where(x => x.Email.Contains(FilterLetters));
                        break;
                    case 3:
                        peopleList = peopleList.Where(x => x.SunSign.Contains(FilterLetters));
                        break;
                    case 4:

                        peopleList = peopleList.Where(x => x.ChineseSign.Contains(FilterLetters));

                        break;
                }

                return peopleList;
            }
        }

        public IEnumerable<string> SortCasesEnum
        {
            get { return _sortCases; }
        }

        public IEnumerable<string> FilterCasesEnum
        {
            get { return _filterCases; }
        }

        public RelayCommand<object> AddPersonCommand
        {
            get
            {
                return _addPersonCommand ?? (_addPersonCommand = new RelayCommand<object>(
                           AddPersonImplementation));
            }
        }

        public RelayCommand<object> EditPersonCommand
        {
            get
            {
                return _editPersonCommand ?? (_editPersonCommand =
                           new RelayCommand<object>(EditPersonImplementation, CanExecuteRemoveOrEdit));
            }
        }

        public RelayCommand<object> RemovePersonCommand
        {
            get
            {
                return _removePersonCommand ?? (_removePersonCommand =
                           new RelayCommand<object>(RemovePersonImplementation, CanExecuteRemoveOrEdit));
            }
        }

        public RelayCommand<object> FilterCommand
        {
            get
            {
                return _filterCommand ?? (_filterCommand = new RelayCommand<object>(
                           (o => { OnPropertyChanged("PersonList"); })));
            }
        }

        #endregion

        private void AddPersonImplementation(object obj)
        {
            StationManager.CurrentPerson = new Person("", "", "");
            NavigationManager.Instance.Navigate(ViewType.AddPersonView);
        }

        private async void RemovePersonImplementation(object obj)
        {

            await Task.Run(() =>
            {
                Person personToRemove = (Person)SelectedPerson;

                DialogResult dr = System.Windows.Forms.MessageBox.Show(
                    "Are you sure you want to delete " + personToRemove.Name + " " + personToRemove.Surname + "?",
                    "Deleting...",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {
                    StationManager.DataStorage.Remove(personToRemove);
                    OnPropertyChanged("PersonList");
                }
            });


        }

        private async void EditPersonImplementation(object obj)
        {


            await Task.Run(() =>
            {
                StationManager.CurrentPerson = (Person)SelectedPerson;

                StationManager.PersonToEdit = new Person(
                    StationManager.CurrentPerson.Name,
                    StationManager.CurrentPerson.Surname,
                    StationManager.CurrentPerson.Email,
                    StationManager.CurrentPerson.Birthday

                );
            });

            if (StationManager.EditPersonVM != null)
                StationManager.EditPersonVM.Update();

            NavigationManager.Instance.Navigate(ViewType.EditPersonView);
        }

        private bool CanExecuteRemoveOrEdit(object obj)
        {
            return SelectedPerson != null;
        }



        public void UpdateInfo()
        {
            OnPropertyChanged("PersonList");
        }
    }
}

