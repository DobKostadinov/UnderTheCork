using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using UnderTheCork.Common;
using UnderTheCork.Data.Models.Abstracts;
using UnderTheCork.Data.Models.Contracts;
using UnderTheCork.Data.Models.Enums;

namespace UnderTheCork.Data.Models
{
    public class Wine : BaseDataModel, IWine
    {
        private ICollection<WineReview> reviews;

        public Wine()
        {
            this.reviews = new HashSet<WineReview>();
        }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(DataModelsConstants.MinLengthWineName)]
        [MaxLength(DataModelsConstants.MaxLengthWineName)]
        public string Name { get; set; }

        [Required]
        [EnumDataType(typeof(WineType))]
        public WineType WineType { get; set; }

        [Required]
        [MinLength(DataModelsConstants.MinLengthGrapeName)]
        [MaxLength(DataModelsConstants.MaxLengthGrapeName)]
        public string Grape { get; set; }

        [Required]
        [Range(DataModelsConstants.MinYearOfWineProduction, 
               DataModelsConstants.MaxYearOfWineProduction)]
        public int Year { get; set; } 

        public Guid WineryId { get; set; }

        public virtual Winery Winery { get; set; }

        public virtual WineImage WineImage { get; set; }

        public virtual ICollection<WineReview> Reviews
        {
            get { return this.reviews; }
            set { this.reviews = value; }
        }
    }
}
