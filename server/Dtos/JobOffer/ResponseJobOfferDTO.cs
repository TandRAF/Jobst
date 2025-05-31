using System.Collections.Generic;

namespace server.Dtos.JobOffer
{
    public class ResponseJobOfferDTO
    {
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public string CompanyTitle { get; set; }
        public int CompanyProfileId { get; set; }
        public DateTime DatePosted { get; set; }
        public List<string> Tags { get; set; }
    }
}