namespace E_commerce.Models.ViewModels
{
    public class ProductVm
    {
        public int productid { get; set; }
        public string productname { get; set; }
        public string productDescription { get; set; }
        public decimal price { get; set; }



        public int categoryid { get; set; }
        public IFormFile photo { get; set; }
    }
}
