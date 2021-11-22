using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1.ViewModels
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    /// <summary>
    /// The Class below has the effect of DataContext to MainView.xaml
    /// And this class implements INotifyPropertyChanged to support one-way and two-way bindings
    /// Such that UI elements updates when the sorce has been changed dynamically
    /// </summary>
    internal class MainViewModel : INotifyPropertyChanged
    {
        private string _inputString;
        private string _upperString;
        /// <summary>
        /// Declare the event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public string InputString
        {
            get { return this._inputString; }
            set
            {
                if(SetProperty(ref this._inputString,value))
                {
                    this.UpperString = this._inputString.ToUpper();
                    System.Diagnostics.Debug.Write("UpperString=" + this.UpperString);
                }
            }
        }

        public string UpperString
        {
            get { return this._upperString; }
            private set { SetProperty(ref this._upperString, value); }
        }

        /// <summary>
        /// The function below works as setting Properties from UI
        /// </summary>
        /// <typeparam name="T">The type of Property</typeparam>
        /// <param name="target">The target Property name</param>
        /// <param name="value">The Setted Value for target Property</param>
        /// <param name="PropertyName">The name of target Property</param>
        /// <returns></returns>
        private bool SetProperty<T>(ref T target, T value, [CallerMemberName] string PropertyName=null)
        {
            if(Equals(target, value))
                return false;
            target = value;
            OnPropertyChanged(PropertyName);
            return true;
        }

        /// <summary>
        /// Create the OnPropertyChanged method to raise the event 
        ///
        /// </summary>
        /// <param name="name"> the calling member's name will be used as parameter</param>
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
