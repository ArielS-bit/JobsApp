using System;
using System.Collections.Generic;


namespace JobsApp.Models
{
    public partial class Rating
    {
        public Rating()
        {
            Employees = new List<Employee>();
        }

        public int RatingId { get; set; }
        public string RatingName { get; set; }

        public virtual List<Employee> Employees { get; set; }
    }
}
