using System;
namespace user_service.Core.Dtos
{
    public class DiscountDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public DiscountDto(int id, string status = "No discount")
        {
            Id = id;
            Name = "General discount";
            Status = status;
        }
    }

    public class DiscountRequestDto
    {
        public int discountId { get; set; }
    }
}
