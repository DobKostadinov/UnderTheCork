using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using UnderTheCork.Common;
using UnderTheCork.Data.Models.Abstracts;
using UnderTheCork.Data.Models.Contracts;

namespace UnderTheCork.Data.Models
{
    public class Country : BaseDataModel, ICountry
    {
        private ICollection<Region> regions;

        public Country()
        {
            this.regions = new HashSet<Region>();
        }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(DataModelsConstants.MinLengthCountryName)]
        [MaxLength(DataModelsConstants.MaxLengthCountryName)]
        public string Name { get; set; }

        public virtual ICollection<Region> Regions
        {
            get { return this.regions; }
            set { this.regions = value; }
        }
    }
}
