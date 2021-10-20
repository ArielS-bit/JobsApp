using System;
using System.Collections.Generic;

namespace JobsApp.Models
{
    public partial class Comment
    {
        public Comment()
        {
            JobOffers = new List<JobOffer>();
            JobRequests = new List<JobRequest>();
        }

        public int CommentId { get; set; }
        public int Content { get; set; }
        public int JobOfferId { get; set; }
        public int JobRequestId { get; set; }
        public int Likes { get; set; }

        public virtual List<JobOffer> JobOffers { get; set; }
        public virtual List<JobRequest> JobRequests { get; set; }
    }
}
