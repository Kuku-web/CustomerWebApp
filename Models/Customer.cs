using System.ComponentModel.DataAnnotations;

namespace CustomerWebApp.Models
{
    public class Customer
    {
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public int Id { get; set; }
    }
}
