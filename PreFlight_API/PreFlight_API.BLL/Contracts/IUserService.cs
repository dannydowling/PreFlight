using PreFlight_API.BLL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PreFlight_API.BLL
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetUserListAsync(int pageNumber, int pageSize);
        Task<UserModel> GetUserAsync(Guid id);
        Task<UserModel> CreateUserAsync(UserModel user);
        Task UpdateUserAsync(UserModel user);
        Task DeleteUserAsync(Guid id);
    }
}
