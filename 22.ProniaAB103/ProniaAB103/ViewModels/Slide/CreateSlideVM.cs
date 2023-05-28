using System.ComponentModel.DataAnnotations;

namespace ProniaAB103.ViewModels
{
    public class CreateSlideVM
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        public string SubTitle { get; set; }

        public string Description { get; set; }

        public int Order { get; set; }

        public IFormFile Photo { get; set; }
    }
}
