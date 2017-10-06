using System;
using System.Collections.Generic;

namespace UnderTheCork.Data.Models.Contracts
{
    public interface IRegion
    {
        string Name { get; set; }

        Guid CountryId { get; set; }

        Country Country { get; set; }

        ICollection<Winery> Wineries { get; set; }
    }
}
