using OvgRlp.Tools.EgvpAddressbook.EgvpEnterpriseSoap;
using OvgRlp.Tools.EgvpAddressbook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OvgRlp.Tools.EgvpAddressbook.Services
{
  internal class EgvpEpService
  {
    private EgvpPortTypeClient m_EgvpClient = null;

    public EgvpEpService(EgvpPortTypeClient egvpClient)
    {
      m_EgvpClient = egvpClient;
    }

    public string GetEgvpEpVersion()
    {
      string version = string.Empty;

      try
      {
        var requ = new getVersionRequest();
        var resp = new getVersionResponse();

        resp = m_EgvpClient.getVersion(requ);
        version = resp.version;
      }
      catch { /* ohne Fehlerbehandlung */ }

      return version;
    }

    public List<EgvpAdressEntry> SearchInEgvpEnterprise(EgvpSearchItem name, EgvpSearchItem firstname, EgvpSearchItem organization,
                                                        EgvpSearchItem street, EgvpSearchItem postcode, EgvpSearchItem city,
                                                        EgvpSearchItem userId)
    {
      var searchResults = new List<EgvpAdressEntry>();
      var requ = new searchReceiverRequest();
      var resp = new searchReceiverResponse();

      requ.userID = Properties.Settings.Default.EgvpEnterpriseUserId;
      requ.searchCriteria = new EgvpEnterpriseSoap.BusinessCardType();
      if (!string.IsNullOrEmpty(name.Value))
        requ.searchCriteria.name = new BCItem() { Value = name.Value, searchMode = name.SearchModeType };
      if (!string.IsNullOrEmpty(firstname.Value))
        requ.searchCriteria.christianName = new BCItem() { Value = firstname.Value, searchMode = firstname.SearchModeType };
      if (!string.IsNullOrEmpty(organization.Value))
        requ.searchCriteria.organization = new BCItem() { Value = organization.Value, searchMode = organization.SearchModeType };
      if (!string.IsNullOrEmpty(street.Value))
        requ.searchCriteria.street = new BCItem() { Value = street.Value, searchMode = street.SearchModeType };
      if (!string.IsNullOrEmpty(postcode.Value))
        requ.searchCriteria.zipCode = new BCItem() { Value = postcode.Value, searchMode = postcode.SearchModeType };
      if (!string.IsNullOrEmpty(city.Value))
        requ.searchCriteria.city = new BCItem() { Value = city.Value, searchMode = city.SearchModeType };
      if (!string.IsNullOrEmpty(userId.Value))
        requ.searchCriteria.userID = new BCItem() { Value = userId.Value, searchMode = userId.SearchModeType };

      resp = m_EgvpClient.searchReceiver(requ);
      if (resp.returnCode != SearchReturnCodeType.OK)
        throw new Exception(resp.returnCode.ToString());
      if (resp.count > 0)
      {
        foreach (var res in resp.receiverResults)
        {
          searchResults.Add(EgvpAdressEntry.FromBusinessCardType(res));
        }
      }

      return searchResults;
    }
  }
}