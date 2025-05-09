using System;

namespace server.Model
{
    public class Company
    {
        public string CompanyName {get; set;} = string.Empty;
        public string? Email {get; set;} = string.Empty;
        public string? Password {get; set;} = string.Empty;
        public List<JobOffer> JobOffers {get; set;} = new List<JobOffer>();
    }
}
