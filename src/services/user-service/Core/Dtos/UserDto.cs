using System;
namespace user_service.Core.Dtos
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DiscountId { get; set; }
        public User(string name)
        {
            Name = name;
        }
    }
}
