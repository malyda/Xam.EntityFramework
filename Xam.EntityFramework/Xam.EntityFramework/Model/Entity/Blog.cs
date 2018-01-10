using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Xam.EntityFramework.Model.Entity
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }

        public virtual List<Article> Articles {get;set;}

        public override string ToString()
        {
            return $"BlogID:{BlogId},URL:{Url},Rating:{Rating}";
        }
    }
}
