namespace xfixWebApi.Models
{
    public class Location
    {
        public int Id { get; set; }

        public string HouseAddress { get; set; }

        public string Area { get; set; }
        
        public ICollection<ApplicationUser> Users { get; set; }
    }
}
