using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using UnderTheCork.Common;
using UnderTheCork.Data.Models.Abstracts;
using UnderTheCork.Data.Models.Contracts;

namespace UnderTheCork.Data.Models
{
    public class Winery : BaseDataModel, IWinery
    {
        private ICollection<Wine> wines;

        public Winery()
        {
            this.wines = new HashSet<Wine>();
        }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(DataModelsConstants.MinLengthWineryName)]
        [MaxLength(DataModelsConstants.MaxLengthWineryName)]
        public string Name { get; set; }  

        public Guid RegionId { get; set; }

        public virtual Region Region { get; set; }

        public virtual ICollection<Wine> Wines
        {
            get { return this.wines; }
            set { this.wines = value; }
        }
    }
}
