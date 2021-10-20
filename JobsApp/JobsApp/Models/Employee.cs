using System;
using System.Collections.Generic;


namespace JobsApp.Models
{
    public partial class Employee
    {
        public Employee()
        {
            JobApplications = new List<JobApplication>();
        }

        public int EmployeeId { get; set; }
        public int UserId { get; set; }
        public bool Employeed { get; set; }
        public int RatingId { get; set; }

        public virtual Rating Rating { get; set; }
        public virtual List<JobApplication> JobApplications { get; set; }
    }
}
