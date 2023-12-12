using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace E_commerce.Models.context
{
    public class AplicationDbcontext : IdentityDbContext
    {
        public AplicationDbcontext(DbContextOptions<AplicationDbcontext> options) : base(options)
        {
        }
      

        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
         
        }



        public DbSet<Category> categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
       
        public DbSet<Card> cards { get; set; }

    }
}
