namespace Porav_Claudiu_Lab2.Models
{
    public class Publisher
    {
        public int ID { get; set; }
        public string PublisherName { get; set; }
        public ICollection<Jocuri>? Books { get; set; }
    }
}
