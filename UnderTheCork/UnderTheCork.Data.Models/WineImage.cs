using System;
using System.ComponentModel.DataAnnotations;

using UnderTheCork.Data.Models.Contracts;

namespace UnderTheCork.Data.Models
{
    public class WineImage : IWineImage
    {
        public WineImage()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        public byte[] Image { get; set; }

        public virtual Wine Wine { get; set; }        
    }
}
