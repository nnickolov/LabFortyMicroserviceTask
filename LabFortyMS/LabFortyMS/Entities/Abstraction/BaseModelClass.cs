using System;
using System.ComponentModel.DataAnnotations;

using LabFortyMS.Interfaces;

namespace LabFortyMS.Entities.Abstraction
{
    public abstract class BaseModelClass : IHasCreationDate
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsActive { get; set; }
    }
}
