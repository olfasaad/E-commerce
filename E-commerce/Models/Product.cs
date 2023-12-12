using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Models
{
    public class Product
    {
       public int  productid {get ; set ; }
        public string productname { get; set;  }
        public string productDescription { get; set; }
        public decimal price { get; set;  }

        public string photo { get; set;  }


        public int categoryid { get; set; }
        [ForeignKey( "categoryid" )]
        public Category category { get; set;  }
      
        public ICollection<Review> reviews { get; set; }

    }
}
