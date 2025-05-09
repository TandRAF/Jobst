using System;

namespace server.Model
{
    public class JobApplication
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public Company Company {get; set;} = new Company();
        public List<CV> AppliedCvs {get; set;} = new List<CV>();
    }
}
