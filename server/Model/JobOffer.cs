using System;

namespace server.Model
{
    public class JobOffer
    {
        public int Id { get; set; } 
        public string Title { get; set; } = string.Empty;
        public int CompanyId {get; set;}
        public List<JobApplication> JobApplications = new List<JobApplication>();

    }
}
