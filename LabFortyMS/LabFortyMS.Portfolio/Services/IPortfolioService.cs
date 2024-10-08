﻿using LabFortyMS.Portfolio.Services.Models;
using System.Threading.Tasks;

namespace LabFortyMS.Portfolio.Services
{
    public interface IPortfolioService
    {
        Task CreateAsync(PortfolioCreateRequestModel request);

        Task UpdatePricesAsync(decimal price);

        Task<UserPortfolioResponseModel> GetForUserAsync(int userId);
    }
}
