using System;
using System.Collections.Generic;

namespace server.Model
{
    public class JobApplication
    {
        public int Id { get; set; }
        public int CompanyProfileId { get; set; }
        public CompanyProfile CompanyProfile { get; set; }
        public List<CV> AppliedCvs { get; set; } = new List<CV>();
    }
}
