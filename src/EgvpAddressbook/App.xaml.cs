using OvgRlp.Tools.EgvpAddressbook.ViewModels;
using OvgRlp.Tools.EgvpAddressbook.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EgvpAddressbook
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var shell = new MainWindow();
            var viewModel = new MainWindowViewModel();
            shell.DataContext = viewModel;
            shell.Show();
        }
    }
}