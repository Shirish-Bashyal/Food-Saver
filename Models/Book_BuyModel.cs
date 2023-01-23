using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Waste_Food_Management.Models;

namespace Waste_Food_Management.Models
{
    public class Book_BuyModel
    {
        [Key]
        public int BookId { get; set; }
        
        public bool IsBooked { get; set; }

        //[ForeignKey("saleid")]
        //public int Sale_id { get; set; }

        //public virtual Submit_Sale_Model saleid { get; set; }
       

        [ForeignKey("buyer")]
        public int BuyerId { get; set; }

        public virtual BuyerModel buyer { get; set; }

        [ForeignKey("sale")]
        public int sale_id { get; set; }

        public virtual Submit_Sale_Model sale { get; set; }










    }
}
