using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace schedule.Models
{
    public class CourseDataAccessLayer
    {
        // string connectionString = "Data Source=(local)\\SQLEXPRESS; Database = SCHEDULE;Persist Security Info=false;User ID='sa';Password='sa';MultipleActiveResultSets=True;Trusted_Connection=False;";
        SqlConnection con;
        
        public CourseDataAccessLayer()
        {
            var confoguration = GetConfiguration();
            con = new SqlConnection(confoguration.GetSection("Data").GetSection("ConnectionString").Value);
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
       return builder.Build();
        }
       
        public IEnumerable<Course> CourseList()
        {
            List<Course> lstCourse = new List<Course>();

            using (con)
            {
                SqlCommand cmd = new SqlCommand("sch.CourseList", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    //Group group = new Group();
                    Course sch = new Course();
                    sch.IdCourse = sdr.GetInt32(0);
                    sch.numCourse = sdr.GetInt32(1);


                    lstCourse.Add(sch);

                }
                con.Close();
            }
            return lstCourse;
        }
    }
}
