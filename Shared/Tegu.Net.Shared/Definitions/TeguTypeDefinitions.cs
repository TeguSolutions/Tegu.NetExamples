using System.Collections.ObjectModel;
using Tegu.Net.Shared.Domains.Tegu.Dtos;

namespace Tegu.Net.Shared.Definitions;

public static class TeguTypeDefinitions
{
    static TeguTypeDefinitions()
    {
        Collection = new ObservableCollection<TeguTypeDto>()
        {
            ArgentineBW,
            ArgentineRed,
            Columbian
        };
    }

    public static ObservableCollection<TeguTypeDto> Collection { get; }

    public static TeguTypeDto ArgentineBW { get; } = new()
    {
        Id = 1, 
        FullName = "Argentine Black and White Tegu", 
        Name = "B&W Tegu", 
        LatinName = "Salvator Merianae",
        Color = "Black & White"
    };

    public static TeguTypeDto ArgentineRed { get; } = new()
    {
        Id = 2, 
        FullName = "Argentine Red Tegu", 
        Name = "Red Tegu", 
        LatinName = "Salvator Rufescens",
        Color = "Red"
    };

    public static TeguTypeDto Columbian { get; } = new()
    {
        Id = 3, 
        FullName = "Colombian Tegu", 
        Name = "Gold Tegu", 
        LatinName = "Tupinambis Teguixin",
        Color = "Gold"
    };
}