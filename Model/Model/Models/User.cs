using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    // Represents the User table
    public class User
    {
        [Key] // Primary key
        public int Id { get; set; } // columns

        //[Required(ErrorMessage = "Name is required")]
        //[StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Email is required")]
        //[EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }



        // Add other properties if needed
    }
}
