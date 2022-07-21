namespace schedule.Models
{
    public class ViewModelUpdate
    {
        public IEnumerable<Format> Format { get; set; }
        public IEnumerable<Course> Course { get; set; }
        public IEnumerable<Note> Note { get; set; }
        public IEnumerable<Group> Group { get; set; }
        public IEnumerable<LectureHall> LectureHall { get; set; }
        public IEnumerable<Subject> Subject { get; set; }
        public IEnumerable<Teacher> Teacher { get; set; }
        public IEnumerable<TimeLessons> TimeLessons { get; set; }
        public IEnumerable<Weekday> Weekday { get; set; }
       // public IEnumerable<Course> Course { get; set; }
       // public IEnumerable<Course> Course { get; set; }
        public Schedule sch { get; set; }
    }
}
