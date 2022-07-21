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
        WeekdayDataAccessLayer objweek = new WeekdayDataAccessLayer();
        //[HttpGet]
        //public IActionResult GrList()
        //{
        //    List<Group> grp = new List<Group>();
        //    grp = objgroup.GroupList().ToList();
        //    return View(grp);
        //}
        public IActionResult Index(int IdCourse, int IdGroup, int IdWeekday)
        {
            dynamic mymodel = new ExpandoObject();
            
            
            mymodel.Course = objcourse.CourseList().ToList();
            mymodel.Weekday = objweek.WeekdayList().ToList();
            if (IdWeekday != 0 && IdGroup == 0)
            {
                mymodel.Schedule = objschedule.ScheduleWeekdayRead(IdWeekday).ToList();
            }
            if (IdCourse == 0 && IdGroup==0 && IdWeekday == 0)
            {
                mymodel.Group = objgroup.GroupList().ToList();
                mymodel.Schedule = objschedule.ScheduleList().ToList();
                return View(mymodel);
            }

            if (IdGroup == 0 && IdCourse != 0 && IdWeekday ==0)
            {
                //mymodel.Group = objgroup.GroupList().ToList();
                mymodel.Group = objgroup.GroupCourseList(IdCourse).ToList();
                mymodel.Schedule = objschedule.ScheduleCourseRead(IdCourse).ToList();
                return View(mymodel);
            }

            if(IdGroup != 0 && IdWeekday==0)
            {
               // mymodel.Group = objgroup.GroupList().ToList();
                mymodel.Schedule = objschedule.ScheduleGroupRead(IdGroup).ToList();
            }
            if (IdGroup != 0 && IdWeekday != 0)
            {
                // mymodel.Group = objgroup.GroupList().ToList();
                mymodel.Schedule = objschedule.ScheduleByIdWeekdayGroupRead(IdWeekday,IdGroup).ToList();
            }
            mymodel.Group = objgroup.GroupList().ToList();


            return View(mymodel);
            
            return View(/*grp*/);
        }

        //public IActionResult GetGroupByCourseId(int IdCourse)
        //{
        //    List<Group> grp = new List<Group>();
        //    grp = objgroup.GroupCourseList(IdCourse).ToList();
        //      return PartialView(grp);
        //}
        [HttpPost]
        public IActionResult DeleteSchedule(int IdSchedule)
        {
            objschedule.Delete_Schedule(IdSchedule);
            return RedirectToAction("Index");
        }



    }
}
