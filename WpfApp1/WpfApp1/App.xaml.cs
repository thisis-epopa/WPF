using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    using WpfApp1.Views;
    using WpfApp1.ViewModels;
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ///<summary>
            ///Create an instance of View/MainView
            /// </summary>
            var w = new MainView();

            ///<summary>
            ///Create an instance of ViewModels/MainViewModel
            /// </summary>
            
            var vm = new MainViewModel();

            /// <summary>
            /// Set an instance of MainViewModel as that of Mainview
            /// </summary>
            
            w.DataContext = vm;

            /// <summary>
            /// Show the MainView;
            /// </summary>
            w.Show();
        }
    }
}
