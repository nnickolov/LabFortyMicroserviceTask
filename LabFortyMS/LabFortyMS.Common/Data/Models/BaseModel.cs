using LabFortyMS.Common.Data.Models.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace LabFortyMS.Common.Data.Models
{
    public abstract class BaseModel : IHasCreationDate
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsActive { get; set; }
    }
}
