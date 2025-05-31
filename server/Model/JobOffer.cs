using System;
using System.Collections.Generic;

namespace server.Model
{
    public class JobOffer
    {
        public int Id { get; set; }
        public string JobTitle { get; set; } = string.Empty;
        public string CompanyTitle { get; set; }
        public int CompanyProfileId { get; set; }
        public DateTime DatePosted { get; set; }
        public CompanyProfile CompanyProfile { get; set; }
        public string CompanyImageUrl { get; set; }
        public List<JobApplication> JobApplications { get; set; } = new();
        public List<string> Tags { get; set; } = new();
    }
}
