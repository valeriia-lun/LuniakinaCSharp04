using System;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using Luniakina04.Models;
using Luniakina04.Tools;
using Luniakina04.Tools.Exceptions;
using Luniakina04.Tools.Managers;
using Luniakina04.Tools.Navigation;

namespace Luniakina04.ViewModels
{
    class AddPersonViewModel : BaseViewModel, INotifyPropertyChanged
    {
        #region Fields

        private Person _person = StationManager.CurrentPerson;
        private RelayCommand<object> _proceedCommand;
        private RelayCommand<object> _cancelCommand;
        #endregion

        public AddPersonViewModel()
        {
        }

        #region Properties
        public Person PersonObj

        {
            get { return _person; }
            set
            {
                _person = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<Object> ProceedCommand
        {
            get
            {
                return _proceedCommand ?? (_proceedCommand = new RelayCommand<object>(
                           ProceedImplementation, CanExecuteProceed));
            }
        }

        public RelayCommand<Object> CancelCommand
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new RelayCommand<object>(
                           CancelImplementation));
            }
        }

        #endregion



        private async void ProceedImplementation(object obj)
        {

            bool res = await Task.Run(() => {
                try
                {
                    _person.Validate();
                }
                catch (PersonDontExistException e)
                {
                    MessageBox.Show($"Error! {e.Message}");
                    return false;
                }
                catch (PersonTooOldException e)
                {
                    MessageBox.Show($"Error! {e.Message}");
                    return false;
                }
                catch (InvalidEmailException e)
                {
                    MessageBox.Show($"Error! {e.Message}");
                    return false;
                }
                catch (InvalidNameException e)
                {
                    MessageBox.Show($"Error! {e.Message}");
                    return false;
                }
                catch (InvalidSurnameException e)
                {
                    MessageBox.Show($"Error! {e.Message}");
                    return false;
                }
                return true;
            });


        }

        private bool CanExecuteProceed(Object obj)
        {
            return !String.IsNullOrWhiteSpace(PersonObj.Email) && !String.IsNullOrWhiteSpace(PersonObj.Name) && !String.IsNullOrWhiteSpace(PersonObj.Surname);
        }

        private void CancelImplementation(object obj)
        {
            StationManager.TablePersonVM.UpdateInfo();
            NavigationManager.Instance.Navigate(ViewType.TableView);
        }
    }
}
