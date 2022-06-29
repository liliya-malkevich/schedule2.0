using Microsoft.AspNetCore.Mvc;
using schedule.Models;
using System.Dynamic;

namespace schedule.Controllers
{
    public class ScheduleController : Controller
    {
        ScheduleDataAccessLayer objschedule = new ScheduleDataAccessLayer();
        GroupDataAccessLayer objgroup = new GroupDataAccessLayer();
        CourseDataAccessLayer objcourse = new CourseDataAccessLayer();
        //[HttpGet]
        //public IActionResult GrList()
        //{
        //    List<Group> grp = new List<Group>();
        //    grp = objgroup.GroupList().ToList();
        //    return View(grp);
        //}
        public IActionResult Index()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.Schedule = objschedule.ScheduleList().ToList();
            mymodel.Group = objgroup.GroupList().ToList();
            mymodel.Course = objcourse.CourseList().ToList();
            
            return View(mymodel);
            
            return View(/*grp*/);
        }

        public IActionResult GetGroupByCourseId(int courseId)
        {
            List<Group> grp = new List<Group>();
            grp = objgroup.GroupCourseList(courseId).ToList();
              return View(grp);
        }




    }
}
