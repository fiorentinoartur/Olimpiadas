using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace App1.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private bool isBusy;


        public bool IsBusy
        {
            set { isBusy = value; }
        }

        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "", Action onChanged = null)
        {
            if(EqualityComparer<T>.Default.Equals(backingStore, value)) 
                return false;
                backingStore = value;
            OnPropertyChanged(propertyName);
            onChanged.Invoke();
                return true;
            
            
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
          => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
