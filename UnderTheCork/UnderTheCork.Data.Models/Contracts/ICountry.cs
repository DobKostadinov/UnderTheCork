using System.Collections.Generic;

namespace UnderTheCork.Data.Models.Contracts
{
    public interface ICountry
    {
        string Name { get; set; }

        ICollection<Region> Regions { get; set; }
    }
}
