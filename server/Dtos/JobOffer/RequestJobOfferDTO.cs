using System.Collections.Generic;

namespace server.Dtos.JobOffer
{
    public class RequestJobOfferDTO
    {
        public string? JobTitle { get; set; }
        public string? CompanyTitle { get; set; }
        public string? CompanyImageUrl { get; set; }
        public DateTime DatePosted { get; set; }
        public List<string>? Tags { get; set; } = new();
    }
}