using System;
using System.Collections.Generic;

namespace DBFirstApproach.Models
{
    public partial class RegisteredUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public DateTime UserRegistrationDate { get; set; }
        public string UserContact { get; set; } = null!;
    }
}
