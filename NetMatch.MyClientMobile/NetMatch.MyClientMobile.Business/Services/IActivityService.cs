using NetMatch.MyClientMobile.Business.Models;

namespace NetMatch.MyClientMobile.Business.Services
{
    public interface IActivityService
    {
        public List<Activity> GetActivities(SearchCriteria searchCriteria);
        public Activity GetActivity(Guid activityID);
    }
}
