using System.ComponentModel.DataAnnotations;

namespace E_commerce.Models
{
    public class Category

    {
        [Key]
        public int Categoryid { get; set; }
        [Required]
        public string Categoryname { get; set; }
        
       
        public ICollection<Product> Products { get; set; }
    }
}
