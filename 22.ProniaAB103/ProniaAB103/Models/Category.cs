using System.ComponentModel.DataAnnotations;

namespace ProniaAB103.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Ad bosh ola bilmez")]
        [MaxLength(25,ErrorMessage ="Ad 25-den uzun ola bilmez")]
        public string Name { get; set; }
        
        public List<Product> Products { get; set; }
    }
}
