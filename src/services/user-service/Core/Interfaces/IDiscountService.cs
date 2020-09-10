using System;
using user_service.Core.Dtos;

namespace user_service.Core.Interfaces
{
    public interface IDiscountService
    {
        public string VerifyDiscount(int id);
        public DiscountDto CreateDiscount();
    }
}
