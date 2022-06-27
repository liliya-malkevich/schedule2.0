using Microsoft.AspNetCore.Mvc;
using schedule.Models;

namespace schedule.Controllers
{
    public class ScheduleController : Controller
    {
        ScheduleDataAccessLayer objschedule = new ScheduleDataAccessLayer();
        public IActionResult Index()
        {
            List<Schedule> schedules = new List<Schedule>();
            schedules = objschedule.ScheduleList().ToList();
            return View(schedules);
        }
    }
}
