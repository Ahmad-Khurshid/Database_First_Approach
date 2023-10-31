using System;
using System.Collections.Generic;

namespace DBFirstApproach.Models
{
    public partial class Bookscategory
    {
        public Bookscategory()
        {
            Books = new HashSet<Book>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; }
    }
}
