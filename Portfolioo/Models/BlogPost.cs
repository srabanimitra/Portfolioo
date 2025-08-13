using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolioo.Models
{
    public class BlogPost
    {
       public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
      

    }
}