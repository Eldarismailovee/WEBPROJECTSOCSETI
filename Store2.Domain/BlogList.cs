using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store2.Domain
{
    public class BlogList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string ImageUrl { get; set; }
        public BlogCategory Category { get; set; }
        public TimeSpan PreparationTime { get; set; }
        public DifficultBlog Difficulty { get; set; }
    }
}
