using System;

using LabFortyMS.Entities;
using LabFortyMS.Services.Interfaces;

namespace LabFortyMS.Services
{
    public class PriceService : IPriceService
    {
        public Price PopulatePrices()
        {
            Random random = new Random();
            double min = 1.0;
            double max = 1000.0;

            double randomValue = min + (random.NextDouble() * (max - min));

            var prices = new Price
            {
                Buy = randomValue,
                Sell = randomValue - 1
            };

            return prices;
        }
    }
}
