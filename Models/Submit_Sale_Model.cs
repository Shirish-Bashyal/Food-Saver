 using MessagePack;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace Waste_Food_Management.Models
{
    public class Submit_Sale_Model
    {
        [Key]
        public int sale_id { get; set; }
        [Required(ErrorMessage = "sale item is required")]

        public string sale_item { get; set; } = String.Empty;
        public string description { get; set; }=string.Empty;

        public int price { get; set; }  
        [Required(ErrorMessage = "Quantity is required")]

        public int quantity { get; set; } 
        public bool IsCooked { get; set; }
        public bool IsBooked { get; set; }







        //[ForeignKey("User")]
        //public int UserId { get; set; }

        //public virtual Book_BuyModel User { get; set; }
       

        [ForeignKey("seller")]
        public int SellerId { get; set; }

        public virtual SellerModel seller { get; set; }





    }
}
