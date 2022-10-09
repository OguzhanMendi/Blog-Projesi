using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.Model.Entities.Concrete
{
    public class UserPassword
    {
        public int UserPwdId { get; set; }
        private DateTime _createdDate = DateTime.Now;

        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
        }

        public string Password { get; set; }

        public int AppUserId { get; set; }

        public AppUser AppUser { get; set; }

    }
}
