using OvgRlp.Tools.EgvpAddressbook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OvgRlp.Tools.EgvpAddressbook.Services
{
  public class OsciMailService
  {
    public const string EGVPIDPATTERN = "[EGVP-ID]";

    public static void createOsciMail(string egvpAdress)
    {
      string to = GetOsciMail(egvpAdress);
      System.Diagnostics.Process.Start(string.Format("mailto:{0}", to));
    }

    public static string GetOsciMail(string egvpAdress)
    {
      return GetOsciMailSetting().Replace(EGVPIDPATTERN, egvpAdress);
    }

    public static string GetOsciMailSetting()
    {
      return Properties.Settings.Default.OsciMailFormat;
    }
  }
}