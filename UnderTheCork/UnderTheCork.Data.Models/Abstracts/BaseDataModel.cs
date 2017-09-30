using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using UnderTheCork.Data.Models.Contracts;

namespace UnderTheCork.Data.Models.Abstracts
{
    public abstract class BaseDataModel : IDeletable, IAuditable
    {
        public BaseDataModel()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        Guid Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeletedOn { get; set; }
    }
}
