using System.Collections.ObjectModel;
using Tegu.Net.Client.Maui.Helper;
using Tegu.Net.Client.Maui.Services;
using Tegu.Net.Shared.Domains.Tegu.Dtos;

namespace Tegu.Net.Client.Maui.Pages;

public partial class ControlsVM : ViewModelBase
{
    #region Injected Services

    private readonly DataService _data;

    #endregion

    #region Lifecycle

    public ControlsVM(DataService data)
    {
        _data = data;

        Init();
    }

    private void Init()
    {
        ListViewTegus = _data.GetTegus();
        CollectionViewTegus = _data.GetTegus();
    }

    #endregion

    [ObservableProperty]
    private ObservableCollection<OwnedTeguDto> listViewTegus;

    [ObservableProperty]
    private OwnedTeguDto listViewSelectedTegu;


    [ObservableProperty]
    private ObservableCollection<OwnedTeguDto> collectionViewTegus;

    [ObservableProperty]
    private OwnedTeguDto collectionViewSelectedTegu;
}