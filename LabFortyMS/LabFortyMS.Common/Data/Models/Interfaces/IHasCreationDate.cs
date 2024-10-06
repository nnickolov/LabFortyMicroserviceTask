using System;

namespace LabFortyMS.Common.Data.Models.Interfaces
{
    public interface IHasCreationDate
    {
        DateTime CreatedOn { get; set; }
    }
}