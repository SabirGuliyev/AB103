using System.ComponentModel.DataAnnotations;

namespace ProniaAB103.Models
{
    public class Client:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Message { get; set; }
        public string Image { get; set; }
        [Required]
        public int ProfessionId { get; set; }
        public Profession Profession { get; set; }

    }
}
