using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using UnderTheCork.Common;
using UnderTheCork.Data.Models.Abstracts;

namespace UnderTheCork.Data.Models
{
    public class WineReview : BaseDataModel
    {
        private ICollection<ReviewComment> comments;

        public WineReview()
        {
            this.comments = new HashSet<ReviewComment>();
        }

        [Required]
        [MinLength(DataModelsConstants.MinLengthWineReviewTitle)]
        [MaxLength(DataModelsConstants.MaxLengthWineReviewTitle)]
        public string Title { get; set; }

        [Required]
        [MinLength(DataModelsConstants.MinLengthWineReviewOpinion)]
        [MaxLength(DataModelsConstants.MaxLengthWineReviewOpinion)]
        public string Opinion { get; set; }

        [Required]
        [Range(DataModelsConstants.MinWineReviewRating,
               DataModelsConstants.MaxWineReviewRating)]
        public int Rating { get; set; }

        public Guid WineId { get; set; }

        public virtual Wine Wine { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<ReviewComment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
