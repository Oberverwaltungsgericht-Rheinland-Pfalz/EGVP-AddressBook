using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OvgRlp.Tools.EgvpAdressbook.Services
{
    public class CommonHelper
    {
        public static string AssemblyVersion()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            return AssemblyVersion(assembly);
        }

        public static string AssemblyVersion(string file)
        {
            string rval = "n.v.";
            if (System.IO.File.Exists(file))
            {
                rval = FileVersionInfo.GetVersionInfo(file).FileVersion.Replace(",", ".").Trim();
            }
            return rval;
        }

        public static string AssemblyVersion(System.Reflection.Assembly assembly)
        {
            string rval = "n.v.";
            if (null != assembly)
            {
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                if (null != assembly)
                    rval = fvi.FileVersion;
            }
            return rval;
        }
    }
}