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

        public int Id { get; set; }
        public int Rating1 { get; set; }

        public virtual List<Employee> Employees { get; set; }
    }
}
