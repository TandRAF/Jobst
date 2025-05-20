using System;
using server.Dtos.CV;
using server.Model;

namespace server.Dtos.UserProfile
{
    public class UserProfileDto
    {
        public int Id {get; set;}
        public ICollection<CvDto>? Cvs {get; set;}
    }
}
