namespace NetMatch.MyClientMobile.Business.Models
{
    public class Activity
    {
        Guid ActivityId { get; set; }
        public string ActivityName { get; set; }
        public float Price { get; set; } 
        public ActivityType ActivityType { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        //beschikbaarheid dictionary?
    }
}
