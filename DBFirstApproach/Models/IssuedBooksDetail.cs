using System;
using System.Collections.Generic;

namespace DBFirstApproach.Models
{
    public partial class IssuedBooksDetail
    {
        public int? AwardingEmployeeId { get; set; }
        public int? IssuedBookId { get; set; }
        public int? UserId { get; set; }
        public DateTime IssuanceDate { get; set; }
        public string? ReturnedStatus { get; set; }
        public DateTime? ReturnedDate { get; set; }

        public virtual BooksAwardingEmployee? AwardingEmployee { get; set; }
        public virtual Book? IssuedBook { get; set; }
        public virtual RegisteredUser? User { get; set; }
    }
}
