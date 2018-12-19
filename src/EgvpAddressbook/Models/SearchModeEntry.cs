using OvgRlp.Tools.EgvpAddressbook.EgvpEnterpriseSoap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OvgRlp.Tools.EgvpAddressbook.Models
{
  public class SearchModeEntry
  {
    public string Name { get; set; }
    public SearchModeType Type { get; set; }

    public SearchModeEntry(string name, SearchModeType type)
    {
      Name = name;
      Type = type;
    }

    public override string ToString()
    {
      return Name;
    }

    public static List<SearchModeEntry> GetAllSearchModes()
    {
      var entries = new List<SearchModeEntry>();
      entries.Add(new SearchModeEntry("ist gleich", SearchModeType.EXACT));
      entries.Add(new SearchModeEntry("enthält", SearchModeType.CONTAINS));
      return entries;
    }
  }
}