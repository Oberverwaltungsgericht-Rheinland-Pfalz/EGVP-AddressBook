using OvgRlp.Tools.EgvpAddressbook.EgvpEnterpriseSoap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OvgRlp.Tools.EgvpAddressbook.Models
{
  public class EgvpAdressEntry
  {
    public string Name { get; set; }
    public string FirstName { get; set; }
    public string Organization { get; set; }

    public string OrganizationUnit { get; set; }
    public string StreetAndNumber { get; set; }
    public string PostCode { get; set; }
    public string City { get; set; }
    public string FederalState { get; set; }
    public string UserId { get; set; }
    public string Type { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    public static EgvpAdressEntry FromBusinessCardType(BusinessCardType postbox)
    {
      var entry = new EgvpAdressEntry();

      if (null != postbox.name && !string.IsNullOrEmpty(postbox.name.Value))
        entry.Name = postbox.name.Value;
      if (null != postbox.christianName && !string.IsNullOrEmpty(postbox.christianName.Value))
        entry.FirstName = postbox.christianName.Value;
      if (null != postbox.organization && !string.IsNullOrEmpty(postbox.organization.Value))
        entry.Organization = postbox.organization.Value;
      if (null != postbox.organizationalUnit && !string.IsNullOrEmpty(postbox.organizationalUnit.Value))
        entry.OrganizationUnit = postbox.organizationalUnit.Value;
      if (null != postbox.street && !string.IsNullOrEmpty(postbox.street.Value))
      {
        entry.StreetAndNumber = postbox.street.Value;
        if (null != postbox.streetNumber && !string.IsNullOrEmpty(postbox.streetNumber.Value))
          entry.StreetAndNumber = entry.StreetAndNumber + " " + postbox.streetNumber.Value;
      }
      if (null != postbox.zipCode && !string.IsNullOrEmpty(postbox.zipCode.Value))
        entry.PostCode = postbox.zipCode.Value;
      if (null != postbox.city && !string.IsNullOrEmpty(postbox.city.Value))
        entry.City = postbox.city.Value;
      if (null != postbox.federalState && !string.IsNullOrEmpty(postbox.federalState.Value))
        entry.FederalState = postbox.federalState.Value;
      if (null != postbox.userID && !string.IsNullOrEmpty(postbox.userID.Value))
        entry.UserId = postbox.userID.Value;
      if (null != postbox.filterID && !string.IsNullOrEmpty(postbox.filterID.Value))
        entry.Type = postbox.filterID.Value;
      if (null != postbox.phone && !string.IsNullOrEmpty(postbox.phone.Value))
        entry.Phone = postbox.phone.Value;
      if (null != postbox.email && !string.IsNullOrEmpty(postbox.email.Value))
        entry.Email = postbox.email.Value;

      return entry;
    }
  }
}