using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using user_service.Core.Dtos;
using user_service.Core.Interfaces;


namespace user_service.Core.Services
{
    public class DiscountService : IDiscountService
    {
        public List<int> discountIds = new List<int> { 1, 2, 3, 4, 5 };

        private readonly ILogger<DiscountService> _logger;

        public DiscountService(ILogger<DiscountService> logger)
        {
            _logger = logger;
        }

        public DiscountDto CreateDiscount()
        {
            var discount = new DiscountDto(discountIds.Count);

            return discount;
        }


        public string VerifyDiscount(int id)
        {
            List<DiscountDto> allDiscount = GetAllDiscounts();
            string status = "No discount";
            foreach(DiscountDto discount in allDiscount)
            {
                if(discount.Id == id)
                {
                    status = "Discount";
                }
            }
            return status;
        }


        private List<DiscountDto> GetAllDiscounts()
        {
            List<DiscountDto> allDiscounts = new List<DiscountDto> { };

            foreach(int discount in discountIds)
            {
                var x = new DiscountDto(discount);
                allDiscounts.Add(x);
            }
            return allDiscounts;
        }
    }
}
