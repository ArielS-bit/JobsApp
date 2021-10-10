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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public bool Employeed { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public int RatingId { get; set; }

        public virtual Rating Rating { get; set; }
        public virtual List<JobApplication> JobApplications { get; set; }
    }
}
