using System;
using server.Dtos.UserProfile;
using server.Model;

namespace server.Mappers
{
    public static class UserProfileMapper
    {
        public static UserProfileDto ToUserProfileDto(this UserProfile upModel){
            return new UserProfileDto
            {
                Id = upModel.Id,
                Cvs = upModel.Cvs.Select(cv=>cv.ToCvDto()).ToList()
            };
        }
    }
}
