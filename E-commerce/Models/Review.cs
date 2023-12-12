using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace E_commerce.Models
{
    public class Review
    {
        public int Reviewid { get; set; }
        public string comment {get ; set;}

        public int productid { get; set; }
        [ForeignKey("productid")]
        public Product product { get; set; }

        public string Userid { get; set; }
        [ForeignKey(nameof(Userid))]
        public User user { get; set; }
 
   }
}
