using System;
using System.Collections.Generic;

namespace UnderTheCork.Data.Models.Contracts
{
    public interface IWinery
    {
        string Name { get; set; }

        Guid RegionId { get; set; }

        Region Region { get; set; }

        ICollection<Wine> Wines { get; set; }
    }
}
