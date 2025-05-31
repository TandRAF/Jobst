using System.Collections.Generic;

namespace server.Model
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<JobOffer> JobOffers { get; set; } = new();
    }
}