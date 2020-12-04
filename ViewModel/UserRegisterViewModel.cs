using LibraryApp.Model;
using LibraryApp.View.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LibraryApp.ViewModel
{
    class UserRegisterViewModel :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name=null)
        {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private bool _canExecute=true;
        public bool CanExecute
        {
            get => _canExecute;
            set
            {
                if (_canExecute.Equals(value))
                    return;
                _canExecute = value;
            }
        }

        private ICommand _saveCommand { get; set; }
        public ICommand SaveCommand
        {
            get { return _saveCommand; }
            set => _saveCommand = value;
        }
        
        private string _email;
        public string TEmail
        {
            get { return _email; }
            set { 
                _email = value;
               // OnPropertyChanged("TEmail");

            }
        }
        
        private string _name;
        public string TName
        {
            get { return _name; }
            set { 
                _name = value;
               // OnPropertyChanged("TName");

            }
        }
        
        private string _surname;
        public string TSurname
        {
            get { return _surname; }
            set { _surname = value;
              //  OnPropertyChanged("TSurname");
            }
        }
        
        private string _phone;
        public string TPhone
        {
            get { return _phone; }
            set { 
                _phone = value;
               // OnPropertyChanged("TPhone");
            }
        }


        private void Save(object parameter)
        {
            var add = new Model.Users
            {
                Email = TEmail,
                Name = TName,
                Phone = TPhone,
                Surname = TSurname

            };
            DatabaseHelpers.Insert(add);
            TEmail = "";
            TName = "";
            TSurname = "";
            TPhone = "";
            MessageBox.Show("Full all info", "My App");
        }
        //ctor
        public UserRegisterViewModel()
        {
            SaveCommand = new RelayCommand(Save, param => CanExecute);
        }
    }
}
