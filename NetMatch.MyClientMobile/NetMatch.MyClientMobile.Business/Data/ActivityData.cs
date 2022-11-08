using NetMatch.MyClientMobile.Business.Models;

namespace NetMatch.MyClientMobile.Business.Data
{
    public class ActivityData : IActivityData
    {
        public List<Activity> activities { get; }

        public ActivityData()
        {
            activities = new List<Activity>();
            activities.Add(new Activity() { ActivityName = "Museum de Pont", ActivityType = ActivityType.Couples, Price = 15.00F, City = "Tilburg", HouseNumber = "1", StreetName = "Wilhelminapark", PostalCode = "5041EA", Latitude = 51.56734D, Longitude = 5.07416D });
            activities.Add(new Activity() { ActivityName = "Dierenpark de Oliemeulen", ActivityType = ActivityType.Kidfriendly, Price = 13.00F, City = "Tilburg", HouseNumber = "30", StreetName = "Reitse Hoevenstraat", PostalCode = "5042EH", Latitude = 51.57066D, Longitude = 5.06214D });
            activities.Add(new Activity() { ActivityName = "Van Abbemuseum", ActivityType = ActivityType.Couples, Price = 13.00F, City = "Eindhoven", HouseNumber = "2", StreetName = "Stratumsedijk", PostalCode = "5611ND", Latitude = 51.43440D, Longitude = 5.48186D });

        }

        public List<Activity> GetActivities(SearchCriteria searchCriteria)
        {
            if (searchCriteria.Price == 0.00F)
            {
                return activities;
            }
            else
            {
                return (List<Activity>)activities.Where(e => e.Price <= searchCriteria.Price);
            }
        }
    }
}
