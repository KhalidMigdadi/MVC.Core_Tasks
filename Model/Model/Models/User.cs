using System.ComponentModel.DataAnnotations;

namespace Model.Models
{

    // represent the user table
    public class User
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
