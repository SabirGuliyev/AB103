using System.ComponentModel.DataAnnotations;

namespace ProniaAB103.ViewModels
{
    public class LoginVM
    {
        [Required]
        public string UsernameOrEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool IsRemember { get; set; }
    }
}
