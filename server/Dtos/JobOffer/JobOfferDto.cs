using System;
using System.Collections.Generic;

namespace server.Dtos.JobOffer
{
    public class JobOfferDTO
    {
        public int Id { get; set; }
        public string JobTitle { get; set; }

        public DateTime DatePosted { get; set; }
        public string CompanyTitle { get; set; }
        public string? CompanyImageUrl { get; set; }
        public List<string> Tags { get; set; } = new();
    }
}