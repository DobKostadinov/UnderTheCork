using System;

namespace UnderTheCork.Data.Models.Contracts
{
    public interface IReviewComment
    {
        string Content { get; set; }

        string UserId { get; set; }

        User User { get; set; }

        Guid WineReviewId { get; set; }

        WineReview WineReview { get; set; }
    }
}
