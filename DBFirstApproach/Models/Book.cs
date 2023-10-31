using System;
using System.Collections.Generic;

namespace DBFirstApproach.Models
{
    public partial class Book
    {
        public int BookId { get; set; }
        public string? BookName { get; set; }
        public int? AuthorId { get; set; }
        public int? CategoryId { get; set; }
        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }

        public virtual Author? Author { get; set; }
        public virtual Bookscategory? Category { get; set; }
    }
}
