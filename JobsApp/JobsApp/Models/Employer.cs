using System;
using System.Collections.Generic;


namespace JobsApp.Models
{
    public partial class Employer
    {
        public Employer()
        {
            JobApplications = new List<JobApplication>();
            JobRequests = new List<JobRequest>();
        }

        public int EmployerId { get; set; }
        public int UserId { get; set; }
        

        public virtual JobOffer JobOffer { get; set; }
        public virtual List<JobApplication> JobApplications { get; set; }
        public virtual List<JobRequest> JobRequests { get; set; }
    }
}
