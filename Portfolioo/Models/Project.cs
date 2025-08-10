using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolioo.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string ImagePath { get; set; }
    }
}