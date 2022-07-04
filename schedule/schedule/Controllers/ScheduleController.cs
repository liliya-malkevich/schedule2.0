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
        public IActionResult Index(int IdCourse)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.Schedule = objschedule.ScheduleList().ToList();
            
            mymodel.Course = objcourse.CourseList().ToList();
            if(IdCourse == 0)
            {
                mymodel.Group = objgroup.GroupList().ToList();
                return View(mymodel);
            }

            mymodel.Group = objgroup.GroupCourseList(IdCourse).ToList();
            return View(mymodel);
            
            return View(/*grp*/);
        }

        //public IActionResult GetGroupByCourseId(int IdCourse)
        //{
        //    List<Group> grp = new List<Group>();
        //    grp = objgroup.GroupCourseList(IdCourse).ToList();
        //      return PartialView(grp);
        //}




    }
}
