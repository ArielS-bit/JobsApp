using System;
using System.Collections.Generic;



namespace JobsApp.Models
{
    public partial class JobOffer
    {
        public JobOffer()
        {
            JobApplications = new List<JobApplication>();
        }

        public int JobOfferId { get; set; }
        public int CategoryId { get; set; }
        public int EmployerId { get; set; }
        public bool Applied { get; set; }//All the employees applied or not
        public int NumApplied { get; set; }//כמה כבר בעבודה הזו
        public string JobTitle { get; set; }
        public int RequiredAge { get; set; }
        public int RequiredEmployees { get; set; }//כמה עובדים צריך בכללי
        public string JobOfferDescription { get; set; }
        public bool IsPrivate { get; set; }
        public int JobOfferStatusId { get; set; }//Empty, little empty and little not, full
        public int CommentId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Comment CommentNavigation { get; set; }
        public virtual Employer Employer { get; set; }
        public virtual JobOfferStatus JobOfferStatus { get; set; }
        public virtual Comment Comment { get; set; }
        public virtual ICollection<JobApplication> JobApplications { get; set; }
    }
}
