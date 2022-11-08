using NetMatch.MyClientMobile.Business.Data;
using NetMatch.MyClientMobile.Business.Models;

namespace NetMatch.MyClientMobile.Business.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityData _activityData;
        public ActivityService(IActivityData activityData)
        {
            _activityData = activityData;
        }

        public List<Activity> GetActivities(SearchCriteria searchCriteria)
        {
            // filter functie met en zonder prijs
            // afstand hemelsbreed enkel te berekenen met wiskundige formule
            return _activityData.GetActivities(searchCriteria);
        }

        public Activity GetActivity(Guid activityID)
        {
            throw new NotImplementedException();
        }
    }
}
