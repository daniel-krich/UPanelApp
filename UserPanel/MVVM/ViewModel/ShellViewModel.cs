using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserPanel.Core;
using UserPanel.MVVM.Model;
using UserPanel.Services;


namespace UserPanel.MVVM.ViewModel
{
    /// <summary>
    /// Controls active ViewModel
    /// </summary>
    public class ShellViewModel : ObservableObject
    {
        public string AppTitle { get; set; } = "My Simple MVVM app";
        public RelayCommand SetMainPage { get; set; }
        private object currentView;
        public object CurrentView
        {
            get
            {
                return this.currentView;
            }
            set
            {
                this.currentView = value;
                OnPropertyChanged();
            }
        }
        public ShellViewModel()
        {
            CurrentView = new LoginViewModel(new Authenticator()); // Initial screen
        }
    }
}
