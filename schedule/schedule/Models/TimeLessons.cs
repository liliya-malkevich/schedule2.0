namespace schedule.Models
{
    public class TimeLessons
    {
        public int IdTimeLesson { get; set; }
        public int numTimeLesson { get; set; }
        public TimeSpan LessonTimeStart { get; set; }
        public TimeSpan LessonTimeEnd { get; set; }
    }
}
