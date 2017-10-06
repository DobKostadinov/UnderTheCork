using System;
using System.Collections.Generic;

namespace UnderTheCork.Data.Models.Contracts
{
    public interface IWineReview
    {
        string Title { get; set; }

        string Opinion { get; set; }

        int Rating { get; set; }

        Guid WineId { get; set; }

        Wine Wine { get; set; }

        string UserId { get; set; }

        User User { get; set; }

        ICollection<ReviewComment> Comments { get; set; }
    }
}
