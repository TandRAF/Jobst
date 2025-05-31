using System;
using System.Collections.Generic;
using server.Dtos.CV;
using server.Dtos.JobOffer;
using server.Model;

namespace server.Dtos.CompanyProfile
{
    public class CompanyProfileDto
    {
        public int Id { get; set; }
        public List<JobOfferDTO> JobOffers { get; set; } = new();
    }
}
