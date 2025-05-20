using System;
using server.Model;

namespace server.Interfaces
{
    public interface IUserProfileRepository
    {
        Task<UserProfile?> GetByIdAsync(string id);
    }
}
