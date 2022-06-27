using System.Data.SqlClient;
namespace schedule.Models
{
    public class ScheduleDataAccessLayer
    {
        string connectionString = "Data Source=(local)\\SQLEXPRESS; Database = SCHEDULE;Persist Security Info=false;User ID='sa';Password='sa';MultipleActiveResultSets=True;Trusted_Connection=False;";
    
        public IEnumerable<Schedule> ScheduleList()
        {
            List<Schedule> lstschedule = new List<Schedule>();

            using(SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sch.ScheduleList", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    Schedule schedule = new Schedule();

                    schedule.WeekdayName = sdr["WeekdayName"].ToString();
                    schedule.numTimeLesson = Convert.ToInt32(sdr["numTimeLesson"]);
                    schedule.SubjectName = sdr["SubjectName"].ToString();
                    schedule.FormatName = sdr["FormatName"].ToString();
                    schedule.LessonTimeStart = sdr.GetTimeSpan(4);
                    schedule.LessonTimeEnd = sdr.GetTimeSpan(5);
                    schedule.numGroup = sdr.GetString(6);
                    schedule.TeacherName = sdr.GetString(7);
                    schedule.LectureHallNum = sdr["LectureHallNum"].ToString();
                    schedule.NoteName = sdr["NoteName"].ToString();
                    lstschedule.Add(schedule);

                }
                con.Close();
            }
            return lstschedule;
        }
    
    }
}
