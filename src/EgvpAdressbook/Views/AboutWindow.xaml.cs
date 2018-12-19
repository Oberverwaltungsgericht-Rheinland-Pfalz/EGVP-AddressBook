using OvgRlp.Tools.EgvpAdressbook.EgvpEnterpriseSoap;
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

namespace OvgRlp.Tools.EgvpAdressbook.Views
{
  /// <summary>
  /// Interaction logic for AboutWindow.xaml
  /// </summary>
  public partial class AboutWindow : Window
  {
    private static EgvpPortTypeClient EgvpClient = new EgvpEnterpriseSoap.EgvpPortTypeClient();

    public string ProgramVersion
    {
      get
      {
        return string.Format("EgvpAdressbook\tVersion {0}{1}EgvpEnterprise\tVersion {2}",
                             OvgRlp.Core.Common.AssemblyHelper.AssemblyVersion(System.Reflection.Assembly.GetExecutingAssembly()),
                             Environment.NewLine,
                             "TODO: EVGP-Enterprise Version");
      }
    }

    public string Copyright
    { get { return "Copyright © 2018" + Environment.NewLine + "Oberverwaltungsgericht Rheinland-Pfalz"; } }

    public string UpdateInformation
    { get { return "neue Versionen finden Sie unter:" + Environment.NewLine + "(nur im Rheinland-Pfalz Netz verfügbar)"; } }

    public string UpdateLink
    { get { return "http://5500s-dev1/OVGRLP.tools/Egvp-AdressBook/tree/master/release"; } }

    public string UpdateLinkDescription
    { get { return "OVGRLP - Versionskontrolle"; } }

    public AboutWindow()
    {
      InitializeComponent();
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
      Close();
    }
  }
}