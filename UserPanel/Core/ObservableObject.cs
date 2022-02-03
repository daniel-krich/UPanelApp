using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UserPanel.MVVM.ViewModel;

namespace UserPanel.Core
{
    public class ObservableObject : ObjectMessanger, INotifyPropertyChanged
    {
        public static ShellViewModel ShellViewModelInstance { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        static ObservableObject()
        {
            ShellViewModelInstance = new ShellViewModel(); // Create ShellViewModel
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
