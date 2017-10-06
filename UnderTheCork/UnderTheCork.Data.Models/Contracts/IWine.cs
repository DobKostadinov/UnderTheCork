using System;
using System.Collections.Generic;

using UnderTheCork.Data.Models.Enums;

namespace UnderTheCork.Data.Models.Contracts
{
    public interface IWine
    {
        string Name { get; set; }

        WineType WineType { get; set; }

        string Grape { get; set; }

        int Year { get; set; }

        Guid WineryId { get; set; }

        Winery Winery { get; set; }

        WineImage WineImage { get; set; }

        ICollection<WineReview> Reviews { get; set; }
    }
}
