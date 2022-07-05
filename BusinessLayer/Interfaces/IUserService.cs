using BusinessLayer.Generic;
using Domain.DataTransferObjects;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IUserService
    {
        UserResponseDto Login(string email, string password);

        UserResponseDto Register(User user, string password, string rePassword);
    }
}
