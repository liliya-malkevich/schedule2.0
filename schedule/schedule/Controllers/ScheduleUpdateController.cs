using Microsoft.AspNetCore.Mvc;
using schedule.Models;
using System.Dynamic;

namespace schedule.Controllers
{
    public class ScheduleUpdateController : Controller
    {
        ScheduleDataAccessLayer objschedule = new ScheduleDataAccessLayer();
        GroupDataAccessLayer objgroup = new GroupDataAccessLayer();
        FormatDataAccessLayer objformat = new FormatDataAccessLayer();
      
        LectureHallDataAccessLayer objlecturehall = new LectureHallDataAccessLayer();
        NoteDataAccessLayer objnote = new NoteDataAccessLayer();
        SubjectDataAccessLayer objsubject = new SubjectDataAccessLayer();
        TeacherDataAccessLayer objteacher = new TeacherDataAccessLayer();
        TimeLessonsDataAccessLayer objtimelesson = new TimeLessonsDataAccessLayer();
        WeekdayDataAccessLayer objweekday = new WeekdayDataAccessLayer();   
        public IActionResult Update(int IdSchedule)
        {
            //dynamic mymodel = new ExpandoObject();
            ViewModelUpdate mymodel = new ViewModelUpdate();
            
            mymodel.Group = objgroup.GroupList().ToList();
            mymodel.Format = objformat.FormatList().ToList();
            mymodel.LectureHall = objlecturehall.LectureHallList().ToList();
            mymodel.Note = objnote.NoteList().ToList();
            mymodel.Teacher = objteacher.TeacherList().ToList();
            mymodel.Subject = objsubject.SubjectList().ToList();
            mymodel.TimeLessons = objtimelesson.TimeLessonsList().ToList();
            mymodel.Weekday = objweekday.WeekdayList().ToList();
            mymodel.sch = IdSchedule == default ? new Schedule() : objschedule.ScheduleLessonRead(IdSchedule);
            return View(mymodel);
            //return View(dataManager.Lesson.GetLessons());
        }
        [HttpPost]
        public IActionResult Update(int id, [Bind] Schedule model)
        {
            model.IdSchedule = id;
            if (ModelState.IsValid)
            {
                objschedule.UpdateSchedule(model);
                return RedirectToAction("Index", "Schedule");
            }
            return View(model);
        }
    }
}
