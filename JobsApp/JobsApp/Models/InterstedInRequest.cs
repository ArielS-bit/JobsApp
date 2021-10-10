using System;
using System.Collections.Generic;


namespace JobsApp.Models
{
    public partial class InterstedInRequest
    {
        public int Id { get; set; }
        public int JobRequestId { get; set; }
        public int EmployerId { get; set; }

        public virtual JobRequest JobRequest { get; set; }
    }
}
