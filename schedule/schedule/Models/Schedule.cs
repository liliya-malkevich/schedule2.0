namespace schedule.Models
{
    public class Schedule
    {
        //public int IdSchedule { get; set; }
        //public int IdLectureHall { get; set; }
        //public int IdTeacher { get; set; }
        //public int IdGroup { get; set; }
        //public int IdWeekday { get; set; }
        //public int IdTimeLesson { get; set; }
        //public int IdSubject { get; set; }
        //public int IdNote { get; set; }
        //public int IdFormat { get; set; }

        public string WeekdayName { get; set; }
        public int numTimeLesson { get; set; }
        public string SubjectName { get; set; }
        public string FormatName { get; set; }
        public Group gr = new Group();
        public TimeSpan LessonTimeStart { get; set; }
        public TimeSpan LessonTimeEnd { get; set; }
        public string numGroup { get; set; }
        public string TeacherName { get; set; }
        public string LectureHallNum { get; set; }
        public string NoteName { get; set; }
    }
}
