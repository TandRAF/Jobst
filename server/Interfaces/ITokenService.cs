using System;
using server.Model;

namespace server.Interfaces
{
    public interface ITokenService
    {
        public Task<string> CreateToken(UserBase user);
    }
}
