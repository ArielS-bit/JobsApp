using System;
using System.Collections.Generic;


namespace JobsApp.Models
{
    public partial class JobOfferStatus
    {
        public JobOfferStatus()
        {
            JobRequests = new List<JobRequest>();
        }

        public int JobOfferStatusId { get; set; }
        public string JobOfferStatus1 { get; set; }

        public virtual JobOffer JobOffer { get; set; }
        public virtual List<JobRequest> JobRequests { get; set; }
    }
}
