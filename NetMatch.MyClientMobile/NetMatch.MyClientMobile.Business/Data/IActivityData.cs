using NetMatch.MyClientMobile.Business.Models;

namespace NetMatch.MyClientMobile.Business.Data
{
    public interface IActivityData
    {
        public List<Activity> GetActivities(SearchCriteria searchCriteria);
    }
}
