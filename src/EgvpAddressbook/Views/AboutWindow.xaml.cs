using OvgRlp.Tools.EgvpAddressbook.EgvpEnterpriseSoap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OvgRlp.Tools.EgvpAddressbook.Views
{
  /// <summary>
  /// Interaction logic for AboutWindow.xaml
  /// </summary>
  public partial class AboutWindow : Window
  {
    private static EgvpPortTypeClient EgvpClient = new EgvpEnterpriseSoap.EgvpPortTypeClient();

    public AboutWindowParameter AboutParams = new AboutWindowParameter();

    public string AppName
    { get { return AboutParams.AppName; } }

    public string AppVersion
    { get { return AboutParams.AppVersion; } }

    public string Copyright
    { get { return AboutParams.Copyright; } }

    public string UpdateInformation
    { get { return AboutParams.UpdateInformation; } }

    public string UpdateLink
    { get { return AboutParams.UpdateLink; } }

    public string UpdateLinkDescription
    { get { return AboutParams.UpdateLinkDescription; } }

    public AboutWindow(AboutWindowParameter par)
    {
      AboutParams = par;
      SetWindowIcon(par.AppIconPath);
      InitializeComponent();
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
      Close();
    }

    private void SetWindowIcon(string appIconPath)
    {
      try
      {
        Uri iconUri = new Uri("pack://application:,,," + appIconPath);
        this.Icon = BitmapFrame.Create(iconUri);
      }
      catch { /*ohne Fehlerbehandlung*/}
    }
  }

  public class AboutWindowParameter
  {
    public string AppName { get; set; }
    public string AppVersion { get; set; }
    public string AppIconPath { get; set; }
    public string Copyright { get; set; }
    public string UpdateInformation { get; set; }
    public string UpdateLink { get; set; }
    public string UpdateLinkDescription { get; set; }
  }
}