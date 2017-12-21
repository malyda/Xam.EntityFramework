using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Xam.EntityFramework
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }

        public List<Article> Articles {get;set;}

        public override string ToString()
        {
            return $"BlogID:{BlogId},URL:{Url},Rating:{Rating}";
        }
    }
}
