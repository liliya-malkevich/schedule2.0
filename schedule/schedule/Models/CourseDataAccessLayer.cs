using System.Data.SqlClient;

namespace schedule.Models
{
    public class CourseDataAccessLayer
    {
        string connectionString = "Data Source=(local)\\SQLEXPRESS; Database = SCHEDULE;Persist Security Info=false;User ID='sa';Password='sa';MultipleActiveResultSets=True;Trusted_Connection=False;";

        public IEnumerable<Course> CourseList()
        {
            List<Course> lstCourse = new List<Course>();

            using (SqlConnection con = new SqlConnection(connectionString))
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
