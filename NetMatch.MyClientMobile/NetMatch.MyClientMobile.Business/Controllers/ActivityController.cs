using Microsoft.AspNetCore.Mvc;
using NetMatch.MyClientMobile.Business.Models;
using NetMatch.MyClientMobile.Business.Services;

namespace NetMatch.MyClientMobile.Business.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpPost("getActivities")]
        public async Task<IActionResult> GetActivities([FromBody]SearchCriteria searchCriteria)
        {
            List<Activity> activities = _activityService.GetActivities(searchCriteria);
            return Ok(activities);
        }
    }
}
