using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;




namespace Waste_Food_Management.Models

{
    public class RegisterModel
    {

        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Full Name")]          // this will be shown in UI not the dataname.
        public string FullName { get; set; } = String.Empty;


        [Required(ErrorMessage = "Address is required")]

        [Display(Name = "Address")]
        public string Address { get; set; } = String.Empty;


        [Required(ErrorMessage = "Phone Number is required")]

        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }


        //[Required(ErrorMessage = "Role is required")]

        //[Display(Name = "Role")]
        //public RoleType Role { get; set; }
        public string Role { get; set; } = String.Empty;





        [Required(ErrorMessage = "Email is required")]

        [Display(Name = "Email")]

        public string Email { get; set; } = string.Empty;
        /// <summary>
        /// The [StringLength] attribute is used to specify the minimum and maximum length of a string field. In this case, the attribute is specifying that the string must be at least 6 characters long and no longer than 100 characters.

        /// The {0}
        ///  placeholder in the error message string represents the name of the field, and the {2}
        ///  and {1}
        ///placeholders represent the minimum and maximum length of the field, respectively.

        ///For example, if the string field is named "Password", the error message would be displayed as "The Password must be at least 6 and at max 100 characters long."

        ///This attribute is often used to ensure that user-provided strings meet certain length requirements, such as passwords that must be at least a certain number of characters long.

        /// </summary>


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = string.Empty;





    }
}

