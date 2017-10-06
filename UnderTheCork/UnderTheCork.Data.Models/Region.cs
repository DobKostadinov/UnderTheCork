using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using UnderTheCork.Common;
using UnderTheCork.Data.Models.Abstracts;
using UnderTheCork.Data.Models.Contracts;

namespace UnderTheCork.Data.Models
{
    public class Region : BaseDataModel, IRegion
    {
        private ICollection<Winery> wineries;

        public Region()
        {
            this.wineries = new HashSet<Winery>();
        }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(DataModelsConstants.MinLengthRegionName)]
        [MaxLength(DataModelsConstants.MaxLengthRegionName)]
        public string Name { get; set; }

        public Guid CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Winery> Wineries
        {
            get { return this.wineries; }
            set { this.wineries = value; }
        }
    }
}
