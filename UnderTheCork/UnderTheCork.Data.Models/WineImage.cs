using System;
using System.ComponentModel.DataAnnotations;

namespace UnderTheCork.Data.Models
{
    public class WineImage
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
