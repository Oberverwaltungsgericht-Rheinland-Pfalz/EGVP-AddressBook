﻿using OvgRlp.Tools.EgvpAdressbook.EgvpEnterpriseSoap;
using OvgRlp.Tools.EgvpAdressbook.Models;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace OvgRlp.Tools.EgvpAdressbook.ViewModels
{
  public class MainWindowViewModel : Prism.Mvvm.BindableBase
  {
    private static EgvpPortTypeClient EgvpClient = new EgvpEnterpriseSoap.EgvpPortTypeClient();

    #region Attribute/Bindings

    public String Title
    {
      get
      {
        return "Egvp Adressabfrage (v. " + OvgRlp.Core.Common.AssemblyHelper.AssemblyVersion(System.Reflection.Assembly.GetExecutingAssembly()) + ")";
      }
    }

    private bool _isBusy;

    public bool IsBusy
    {
      get { return _isBusy; }
      set
      {
        if (!value)
          IsLodingAnimationVisible = System.Windows.Visibility.Collapsed;
        if (value)
          IsLodingAnimationVisible = System.Windows.Visibility.Visible;

        SetProperty(ref _isBusy, value);
      }
    }

    private System.Windows.Visibility _isLodingAnimationVisible;

    public System.Windows.Visibility IsLodingAnimationVisible
    {
      get { return _isLodingAnimationVisible; }
      set { SetProperty(ref _isLodingAnimationVisible, value); }
    }

    private string _infotext;

    public string Infotext
    {
      get { return _infotext; }
      set { SetProperty(ref _infotext, value); }
    }

    private string _name;

    public string Name
    {
      get { return _name; }
      set { SetProperty(ref _name, value); }
    }

    private string _street;

    public string Street
    {
      get { return _street; }
      set { SetProperty(ref _street, value); }
    }

    private string _Postcode;

    public string Postcode
    {
      get { return _Postcode; }
      set { SetProperty(ref _Postcode, value); }
    }

    private string _city;

    public string City
    {
      get { return _city; }
      set { SetProperty(ref _city, value); }
    }

    private string _userId;

    public string UserId
    {
      get { return _userId; }
      set { SetProperty(ref _userId, value); }
    }

    private EgvpAdressEntry _selectedAdress;

    public EgvpAdressEntry SelectedAdress
    {
      get { return _selectedAdress; }
      set { SetProperty(ref _selectedAdress, value); }
    }

    private readonly CollectionView _nameSearchModeEntries;

    public CollectionView NameSearchModeEntries
    {
      get { return _nameSearchModeEntries; }
    }

    private SearchModeType _nameSearchModeType;

    public SearchModeType NameSearchModeType
    {
      get { return _nameSearchModeType; }
      set { SetProperty(ref _nameSearchModeType, value); }
    }

    private readonly CollectionView _streetSearchModeEntries;

    public CollectionView StreetSearchModeEntries
    {
      get { return _streetSearchModeEntries; }
    }

    private SearchModeType _streetSearchModeType;

    public SearchModeType StreetSearchModeType
    {
      get { return _streetSearchModeType; }
      set { SetProperty(ref _streetSearchModeType, value); }
    }

    private readonly CollectionView _postcodeSearchModeEntries;

    public CollectionView PostcodeSearchModeEntries
    {
      get { return _postcodeSearchModeEntries; }
    }

    private SearchModeType _postcodeSearchModeType;

    public SearchModeType PostcodeSearchModeType
    {
      get { return _postcodeSearchModeType; }
      set { SetProperty(ref _postcodeSearchModeType, value); }
    }

    private readonly CollectionView _citySearchModeEntries;

    public CollectionView CitySearchModeEntries
    {
      get { return _citySearchModeEntries; }
    }

    private SearchModeType _citySearchModeType;

    public SearchModeType CitySearchModeType
    {
      get { return _citySearchModeType; }
      set { SetProperty(ref _citySearchModeType, value); }
    }

    private readonly CollectionView _userIdSearchModeEntries;

    public CollectionView UserIdSearchModeEntries
    {
      get { return _userIdSearchModeEntries; }
    }

    private SearchModeType _userIdSearchModeType;

    public SearchModeType UserIdSearchModeType
    {
      get { return _userIdSearchModeType; }
      set { SetProperty(ref _userIdSearchModeType, value); }
    }

    private ObservableCollection<EgvpAdressEntry> _searchEntries;

    private CollectionViewSource SearchCollection;

    public ICollectionView SourceSearchCollection
    {
      get { return this.SearchCollection.View; }
    }

    private Brush _informationBackroundColor;

    public Brush InformationBackroundColor
    {
      get { return _informationBackroundColor; }
      set { SetProperty(ref _informationBackroundColor, value); }
    }

    #endregion Attribute/Bindings

    #region delegates

    public DelegateCommand SearchDelegateCommand { get; private set; }
    public DelegateCommand SelectedDelegateCommand { get; private set; }

    #endregion delegates

    public MainWindowViewModel()
    {
      this.IsBusy = false;

      SearchDelegateCommand = new DelegateCommand(Search, CanSearch);
      SelectedDelegateCommand = new DelegateCommand(CopyToClipboard);

      this._nameSearchModeEntries = new CollectionView(SearchModeEntry.GetAllSearchModes());
      this._streetSearchModeEntries = new CollectionView(SearchModeEntry.GetAllSearchModes());
      this._postcodeSearchModeEntries = new CollectionView(SearchModeEntry.GetAllSearchModes());
      this._citySearchModeEntries = new CollectionView(SearchModeEntry.GetAllSearchModes());
      this._userIdSearchModeEntries = new CollectionView(SearchModeEntry.GetAllSearchModes());

      this._searchEntries = new ObservableCollection<EgvpAdressEntry>();

      this.SearchCollection = new CollectionViewSource();
      this.SearchCollection.Source = _searchEntries;

      this.UserIdSearchModeType = SearchModeType.EXACT;
    }

    private bool CanSearch()
    {
      return !IsBusy;
    }

    public void CopyToClipboard()
    {
      if (null != SelectedAdress)
      {
        System.Windows.Clipboard.SetText(SelectedAdress.UserId);
        System.Windows.MessageBox.Show("Egvp Adresse wurde in die Zwischenablage kopiert!");   //TODO: andere (WPF-verträglichere) Lösung finden
      }
    }

    private async void Search()
    {
      this.IsBusy = true;
      _searchEntries.Clear();

      List<EgvpAdressEntry> searchResults = null;
      await Task.Run(() => searchResults = SearchInEgvpEnterprise());

      _searchEntries.AddRange(searchResults);
      this.SearchCollection.View.Refresh();
      this.IsBusy = false;
    }

    private List<EgvpAdressEntry> SearchInEgvpEnterprise()
    {
      var searchResults = new List<EgvpAdressEntry>();

      try
      {
        var requ = new searchReceiverRequest();
        var resp = new searchReceiverResponse();

        requ.userID = Properties.Settings.Default.EgvpEnterpriseUserId;
        requ.searchCriteria = new EgvpEnterpriseSoap.BusinessCardType();
        if (!string.IsNullOrEmpty(this.Name))
          requ.searchCriteria.name = new BCItem() { Value = this.Name, searchMode = this.NameSearchModeType };
        if (!string.IsNullOrEmpty(this.Street))
          requ.searchCriteria.street = new BCItem() { Value = this.Street, searchMode = this.StreetSearchModeType };
        if (!string.IsNullOrEmpty(this.Postcode))
          requ.searchCriteria.zipCode = new BCItem() { Value = this.Postcode, searchMode = this.PostcodeSearchModeType };
        if (!string.IsNullOrEmpty(this.City))
          requ.searchCriteria.city = new BCItem() { Value = this.City, searchMode = this.CitySearchModeType };
        if (!string.IsNullOrEmpty(this.UserId))
          requ.searchCriteria.userID = new BCItem() { Value = this.UserId, searchMode = this.UserIdSearchModeType };

        resp = EgvpClient.searchReceiver(requ);
        if (resp.returnCode != SearchReturnCodeType.OK)
          throw new Exception(resp.returnCode.ToString());
        if (resp.count == 0)
        {
          this.InformationBackroundColor = Brushes.Yellow;
          this.Infotext = "Zu dieser Selektion konnte kein Postfach ermittelt werden!";
        }
        else
        {
          foreach (var res in resp.receiverResults)
          {
            searchResults.Add(EgvpAdressEntry.FromBusinessCardType(res));
          }

          this.InformationBackroundColor = Brushes.Transparent;
          this.Infotext = "Anzahl Suchergebnisse: " + resp.count;
        }
      }
      catch (Exception ex)
      {
        this.InformationBackroundColor = Brushes.Red;
        this.Infotext = "Fehler bei der Suche aufgetreten: " + ex.Message;
      }

      return searchResults;
    }
  }
}