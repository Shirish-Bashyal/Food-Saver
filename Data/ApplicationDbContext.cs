using Microsoft.EntityFrameworkCore;

namespace Waste_Food_Management.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                                          : base(options)
        { }

        public DbSet<Waste_Food_Management.Models.RegisterModel> tbl_register { get; set; }
        public DbSet<Waste_Food_Management.Models.Submit_Sale_Model> tbl_Sale { get; set; }

        public DbSet<Waste_Food_Management.Models.Book_BuyModel> tbl_Book_Buy { get; set; }

       public DbSet<Waste_Food_Management.Models.BuyerModel> tbl_buyer { get; set; }
        public DbSet<Waste_Food_Management.Models.SellerModel> tbl_seller { get; set; }





    }
}
