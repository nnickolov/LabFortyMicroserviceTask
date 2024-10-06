using System.Threading.Tasks;

namespace LabFortyMS.Prices.Services
{
    public interface IPriceService
    {
        Task<decimal> GenerateAsync();
    }
}
