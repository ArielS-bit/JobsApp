using System;
using System.Collections.Generic;


namespace JobsApp.Models
{
    public partial class Employer
    {
        public Employer()
        {
            JobApplications = new List<JobApplication>();
        }

        public int EmployerId { get; set; }
        public int UserId { get; set; }
        public bool IsEmployee { get; set; }

        public virtual JobOffer JobOffer { get; set; }
        public virtual List<JobApplication> JobApplications { get; set; }
    }
}
