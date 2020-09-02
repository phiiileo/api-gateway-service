using System;
using System.Collections.Generic;
using user_service.Core.Dtos;

namespace user_service.Core.Interfaces
{
    public interface IUserService
    {
        List<User> getAllUsers();
        User getUserbyId(int id);
    }
}
