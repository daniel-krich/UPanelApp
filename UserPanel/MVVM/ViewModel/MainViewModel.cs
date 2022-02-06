using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserPanel.Core;
using UserPanel.MVVM.Model;
using UserPanel.Services;
using System.Runtime.CompilerServices;

namespace UserPanel.MVVM.ViewModel
{

    public class MainViewModel : BaseViewModel
    {
        private string _appTitle = "My simple MVVM app";
        public string AppTitle
        {
            get
            {
                return _appTitle;
            }
            set
            {
                _appTitle = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand SetMainPage { get; set; }
        private object _currentView;
        public object CurrentView
        {
            get
            {
                return _currentView;
            }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            
        }
    }
}
