using System.ComponentModel.DataAnnotations;

namespace Xam.EntityFramework.Model.Entity
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
