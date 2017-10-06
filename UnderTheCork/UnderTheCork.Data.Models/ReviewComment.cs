using System;
using System.ComponentModel.DataAnnotations;

using UnderTheCork.Common;
using UnderTheCork.Data.Models.Abstracts;
using UnderTheCork.Data.Models.Contracts;

namespace UnderTheCork.Data.Models
{
    public class ReviewComment : BaseDataModel, IReviewComment
    {
        [Required]
        [MinLength(DataModelsConstants.MinLengthReviewContent)]
        [MaxLength(DataModelsConstants.MaxLengthReviewContent)]
        public string  Content { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public Guid WineReviewId { get; set; }

        public virtual WineReview WineReview { get; set; }
    }
}
