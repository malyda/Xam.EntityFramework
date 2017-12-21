using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Xam.EntityFramework
{
   public class Article
    {
        [Key]
        public int ArticleId { get; set; }
        public string Content { get; set; }
        public override string ToString()
        {
            return $"ArticleID:{ArticleId},Content:{Content}";
        }
    }
}
