using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Models
{
    public class Card
    {
        [Key]
        public int cardid { get; set; }
        
        public int Quantity { get; set; }
        public int productid { get; set; }
       
        [ForeignKey(nameof(productid))]
        public Product product { get; set; }
        public string Userid { get; set; }
        [ForeignKey(nameof(Userid))]
        public User user { get; set; }
    }
}
