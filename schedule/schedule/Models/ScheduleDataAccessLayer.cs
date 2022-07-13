using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
namespace schedule.Models
{
    public class ScheduleDataAccessLayer
    {
        // string connectionString = "Data Source=(local)\\SQLEXPRESS; Database = SCHEDULE;Persist Security Info=false;User ID='sa';Password='sa';MultipleActiveResultSets=True;Trusted_Connection=False;";
        // string connectionString = _configuration.GetConnectionString("myDb1");

        SqlConnection con;

        public ScheduleDataAccessLayer()
        {
            var confoguration = GetConfiguration();
            con = new SqlConnection(confoguration.GetSection("Data").GetSection("ConnectionString").Value);
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }

        public IEnumerable<Schedule> ScheduleList()
        {
            List<Schedule> lstschedule = new List<Schedule>();

            using(con)
            {
                SqlCommand cmd = new SqlCommand("sch.ScheduleList", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    Schedule schedule = new Schedule();
                    schedule.IdSchedule = Convert.ToInt32(sdr["IdSchedule"]);
                    schedule.WeekdayName = sdr["WeekdayName"].ToString();
                    schedule.numTimeLesson = Convert.ToInt32(sdr["numTimeLesson"]);
                    schedule.SubjectName = sdr["SubjectName"].ToString();
                    schedule.FormatName = sdr["FormatName"].ToString();
                    schedule.LessonTimeStart = sdr.GetTimeSpan(5);
                    schedule.LessonTimeEnd = sdr.GetTimeSpan(6);
                    schedule.numGroup = sdr.GetString(7);
                    //schedule.gr.numGroup = sdr.GetString(6);
                    schedule.TeacherName = sdr.GetString(8);
                    schedule.LectureHallNum = sdr["LectureHallNum"].ToString();
                    schedule.NoteName = sdr["NoteName"].ToString();
                    lstschedule.Add(schedule);

                }
                con.Close();
            }
            return lstschedule;
        }

        public IEnumerable<Schedule> ScheduleGroupRead(int IdGroup)
        {
            List<Schedule> lstschedule = new List<Schedule>();

            using (con)
            {
                SqlCommand cmd = new SqlCommand("sch.ScheduleGroupRead", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdGroup", IdGroup);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    Schedule schedule = new Schedule();

                    schedule.IdSchedule = Convert.ToInt32(sdr["IdSchedule"]);
                    schedule.WeekdayName = sdr["WeekdayName"].ToString();
                    schedule.numTimeLesson = Convert.ToInt32(sdr["numTimeLesson"]);
                    schedule.SubjectName = sdr["SubjectName"].ToString();
                    schedule.FormatName = sdr["FormatName"].ToString();
                    schedule.LessonTimeStart = sdr.GetTimeSpan(5);
                    schedule.LessonTimeEnd = sdr.GetTimeSpan(6);
                    schedule.numGroup = sdr.GetString(7);
                    //schedule.gr.numGroup = sdr.GetString(6);
                    schedule.TeacherName = sdr.GetString(8);
                    schedule.LectureHallNum = sdr["LectureHallNum"].ToString();
                    schedule.NoteName = sdr["NoteName"].ToString();
                    lstschedule.Add(schedule);

                }
                con.Close();
            }
            return lstschedule;
        }

      
        public void Delete_Schedule(int IdSchedule)
        {
            List<Schedule> lstschedule = new List<Schedule>();

            using (con)
            {
                SqlCommand cmd = new SqlCommand("sch.ScheduleDelete", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", IdSchedule);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        
        }

        public void UpdateSchedule(Schedule schedule)
        {
            using(con)
            {
                SqlCommand cmd = new SqlCommand("ScheduleUpdate", con);
                cmd.CommandType=System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdSchedule", schedule.IdSchedule);
                cmd.Parameters.AddWithValue("@IdLectureHall", schedule.IdLectureHall);
                cmd.Parameters.AddWithValue("@IdTeacher", schedule.IdTeacher);
                cmd.Parameters.AddWithValue("@IdGroup", schedule.IdGroup);
                cmd.Parameters.AddWithValue("@IdWeekday", schedule.IdWeekday);
                cmd.Parameters.AddWithValue("@IdTimeLesson", schedule.IdTimeLesson);
                cmd.Parameters.AddWithValue("@IdSubject", schedule.IdSubject);
                cmd.Parameters.AddWithValue("@IdNote", schedule.IdNote);
                cmd.Parameters.AddWithValue("@IdFormat", schedule.IdFormat);

                con.Open();
                cmd.ExecuteNonQuery();
                    con.Close();
            }
        }
    }
}
