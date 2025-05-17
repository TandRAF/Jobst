using System;

namespace server.Model
{
    public class CompanyProfile
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public UserBase? User { get; set; }
        public ICollection<JobOffer>? JobOffers {get;set;}
    }
}
