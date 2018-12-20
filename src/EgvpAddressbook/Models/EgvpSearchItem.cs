using OvgRlp.Tools.EgvpAddressbook.EgvpEnterpriseSoap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OvgRlp.Tools.EgvpAddressbook.Models
{
  public class EgvpSearchItem
  {
    public string Value { get; set; }
    public SearchModeType SearchModeType { get; set; }

    public EgvpSearchItem(string value, SearchModeType searchModeType = SearchModeType.CONTAINS)
    {
      this.Value = value;
      this.SearchModeType = searchModeType;
    }

    public EgvpSearchItem()
    {
      this.SearchModeType = SearchModeType.CONTAINS;
    }
  }
}