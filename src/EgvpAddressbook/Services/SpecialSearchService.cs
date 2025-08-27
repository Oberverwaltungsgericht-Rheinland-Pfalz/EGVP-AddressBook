using OvgRlp.Tools.EgvpAddressbook.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OvgRlp.Tools.EgvpAddressbook.Services
{
  public class SpecialSearchService
  {
    private const string USERTYPE_RESTRICTION = "ozg_postfach";
    private const char CSV_Delemitter = ';';
    private const int CSV_Column = 1;

    public List<string> postcodes = new List<string>();

    public SpecialSearchService()
    { }

    public void LoadPostcodesFromFile(string inputFile)
    {
      if (!File.Exists(inputFile))
        throw new FileNotFoundException("Datei konnte nicht gefunden werden!", inputFile);

      foreach (string line in File.ReadAllLines(inputFile))
      {
        string[] parts = line.Split(CSV_Delemitter);
        string field = parts[CSV_Column - 1].Replace(" ", string.Empty).Replace("\"", string.Empty);
        if (!string.IsNullOrEmpty(field) && field.ToUpper() != "null")
        {
          AddUniqueField(field);
        }
      }
    }

    private bool AddUniqueField(string postcode)
    {
      bool rval = false;

      if (!postcodes.Exists(r => r == postcode))
      {
        rval = true;
        //var recipient = new EgvpRecipient { EgvpId = postcode };
        postcodes.Add(postcode);
      }
      return rval;
    }

    public void AddLineToFile(string filePath, string lineToAdd)
    {
      // Überprüfen, ob die Datei vorhanden ist. Wenn nicht, erstellen Sie sie.
      if (!File.Exists(filePath))
      {
        using (StreamWriter sw = File.CreateText(filePath))
        {
          sw.WriteLine(lineToAdd);
        }
      }
      else
      {
        // Datei existiert bereits, fügen Sie die Zeile hinzu.
        using (StreamWriter sw = File.AppendText(filePath))
        {
          sw.WriteLine(lineToAdd);
        }
      }
    }
  }
}