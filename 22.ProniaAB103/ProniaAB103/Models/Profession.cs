namespace ProniaAB103.Models
{
    public class Profession:BaseEntity
    {
        public string Name { get; set; }
        public List<Client> Clients { get; set; }
    }
}
