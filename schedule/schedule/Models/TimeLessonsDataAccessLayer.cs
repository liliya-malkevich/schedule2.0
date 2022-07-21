using System.Data.SqlClient;

namespace schedule.Models
{
    public class TimeLessonsDataAccessLayer
    {
        SqlConnection con;

        public TimeLessonsDataAccessLayer()
        {
            var confoguration = GetConfiguration();
            con = new SqlConnection(confoguration.GetSection("Data").GetSection("ConnectionString").Value);
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
        public IEnumerable<TimeLessons> TimeLessonsList()
        {
            List<TimeLessons> lstTimeLessons = new List<TimeLessons>();

            using (con)
            {
                SqlCommand cmd = new SqlCommand("sch.TimeLessonsList", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    TimeLessons TimeLesson = new TimeLessons();
                    TimeLesson.IdTimeLesson = Convert.ToInt32(sdr["IdTimeLesson"]);
                    TimeLesson.numTimeLesson = Convert.ToInt32(sdr["numTimeLesson"]);
                    TimeLesson.LessonTimeStart = sdr.GetTimeSpan(2);
                    TimeLesson.LessonTimeEnd = sdr.GetTimeSpan(3);


                    lstTimeLessons.Add(TimeLesson);

                }
                con.Close();
            }
            return lstTimeLessons;
        }
    }
}
