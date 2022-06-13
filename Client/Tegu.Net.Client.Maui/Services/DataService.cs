using System.Collections.ObjectModel;
using Tegu.Net.Shared.Definitions;
using Tegu.Net.Shared.Domains.Tegu.Dtos;
using Tegu.Net.Shared.Domains.User.Dtos;
using Tegu.Net.Shared.Helper.Extensions;

namespace Tegu.Net.Client.Maui.Services;

public class DataService
{
    private List<UserDto> users;
    private List<OwnedTeguDto> tegus;

    public DataService()
    {
        InitFakeData();
    }

    private void InitFakeData()
    {
        #region Users

        var admintegu = new UserDto
        {
            Id = Guid.Parse("b1ad8f85-f34a-4b0f-bf63-bfeb5f6173f4"),
            Email = "admintegu@tegu.net",
            FirstName = "Admin",
            LastName = "Tegu",
        };

        var bwtegu = new UserDto
        {
            Id = Guid.Parse("079f5040-3662-4897-b827-d3505ea2438a"),
            Email = "bwtegu@tegu.net",
            FirstName = "B&W",
            LastName = "Tegu",
        };

        var mixedtegu = new UserDto
        {
            Id = Guid.Parse("6c266242-a52a-46d1-9083-dcf0f3745957"),
            Email = "mixedtegu@tegu.net",
            FirstName = "Mixed",
            LastName = "Tegu",
        };

        var notegu = new UserDto
        {
            Id = Guid.Parse("28218d70-5b0d-4d19-8171-1cae6ae75d30"),
            Email = "notegu@tegu.net",
            FirstName = "No",
            LastName = "Tegu",
        };

        #endregion

        var bwtegu_tegu1 = new OwnedTeguDto
        {
            Id = Guid.Parse("6f867827-f9bc-4163-aca1-f702430613d7"),
            Owner = bwtegu,
            TeguType = TeguTypeDefinitions.ArgentineBW,
            Name = "The Beast"
        };

        var mixedtegu_tegu1 = new OwnedTeguDto
        {
            Id = Guid.Parse("df37fe94-6167-4be4-8270-0fdee04a83e8"),
            Owner = mixedtegu,
            TeguType = TeguTypeDefinitions.ArgentineBW,
            Name = "Stop hiding!"
        };
        var mixedtegu_tegu2 = new OwnedTeguDto
        {
            Id = Guid.Parse("317d3ecd-3a02-4e39-9e8b-b30d31494b72"),
            Owner = mixedtegu,
            TeguType = TeguTypeDefinitions.ArgentineRed,
            Name = "Don't eat my shoes!"
        };
        var mixedtegu_tegu3 = new OwnedTeguDto
        {
            Id = Guid.Parse("e3757b2f-734f-43ad-b0d4-1300766ed7a0"),
            Owner = mixedtegu,
            TeguType = TeguTypeDefinitions.Columbian,
            Name = "No, those fingers are not food!"
        };

        users = new List<UserDto>()
        {
            admintegu,
            bwtegu,
            mixedtegu,
            notegu
        };
        tegus = new List<OwnedTeguDto>
        {
            bwtegu_tegu1,
            mixedtegu_tegu1,
            mixedtegu_tegu2,
            mixedtegu_tegu3
        };
    }

    public ObservableCollection<OwnedTeguDto> GetTegus()
    {
        return tegus.ToObservableCollection();
    }
}