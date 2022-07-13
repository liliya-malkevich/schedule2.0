using System.Data.SqlClient;

namespace schedule.Models
{
    public class LectureHallDataAccessLayer
    {
            SqlConnection con;

            public LectureHallDataAccessLayer()
            {
                var confoguration = GetConfiguration();
                con = new SqlConnection(confoguration.GetSection("Data").GetSection("ConnectionString").Value);
            }

            public IConfigurationRoot GetConfiguration()
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build();
            }
            public IEnumerable<LectureHall> LectureHallList()
            {
                List<LectureHall> lstLectureHall = new List<LectureHall>();

                using (con)
                {
                    SqlCommand cmd = new SqlCommand("sch.LectureHallList", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                    LectureHall lectureHall = new LectureHall();
                    lectureHall.IdLectureHall = Convert.ToInt32(sdr["IdLectureHall"]);
                    lectureHall.LectureHallName = sdr["LectureHallName"].ToString();

                        lstLectureHall.Add(lectureHall);

                    }
                    con.Close();
                }
                return lstLectureHall;
            }
        }
}
