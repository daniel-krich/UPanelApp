using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UserPanel.MVVM.ViewModel;

namespace UserPanel.MVVM.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public async void AutoUpdateProperty(int frequency, [CallerMemberName] string name = null)
        {
            await Task.Delay(frequency);
            OnPropertyChanged(name);
        }

        public virtual void Dispose() { }
    }
}
