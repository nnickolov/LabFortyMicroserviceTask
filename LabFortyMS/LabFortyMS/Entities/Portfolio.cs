using LabFortyMS.Entities.Abstraction;

namespace LabFortyMS.Entities
{
    public class Portfolio : BaseModelClass
    {
        public Order Order { get; set; }
    }
}
