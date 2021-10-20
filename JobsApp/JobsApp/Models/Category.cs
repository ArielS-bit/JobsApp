using System;
using System.Collections.Generic;

namespace JobsApp.Models
{
    public partial class Category
    {
        public Category()
        {
            JobOffers = new List<JobOffer>();
            JobRequests = new List<JobRequest>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual List<JobOffer> JobOffers { get; set; }
        public virtual List<JobRequest> JobRequests { get; set; }
    }
}
