using System;
using System.Collections.Generic;


namespace JobsApp.Models
{
    public partial class UserType
    {
        public UserType()
        {
            Users = new List<User>();
        }

        public int UserTypeId { get; set; }
        public string UserTypeName { get; set; }

        public virtual List<User> Users { get; set; }
    }
}
