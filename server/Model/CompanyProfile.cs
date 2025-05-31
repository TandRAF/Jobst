using System;
using System.Collections.Generic;

namespace server.Model
{
    public class CompanyProfile
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public UserBase? User { get; set; }
        public List<JobOffer>? JobOffers { get; set; } = new List<JobOffer>();
    }
}
