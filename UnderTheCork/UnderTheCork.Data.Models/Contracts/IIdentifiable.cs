using System;

namespace UnderTheCork.Data.Models.Contracts
{
    public interface IIdentifiable
    {
        Guid Id { get; set; }
    }
}
