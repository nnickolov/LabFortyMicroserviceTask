using LabFortyMS.Entities.Abstraction;

namespace LabFortyMS.Entities
{
    public class Price : BaseModelClass
    {
        public double? Buy { get; set; }
        public double? Sell { get; set; }
    }
}