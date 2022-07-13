using System.Data.SqlClient;

namespace schedule.Models
{
    public class TeacherDataAccessLayer
    {
        SqlConnection con;

        public TeacherDataAccessLayer()
        {
            var confoguration = GetConfiguration();
            con = new SqlConnection(confoguration.GetSection("Data").GetSection("ConnectionString").Value);
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
        public IEnumerable<Teacher> TeacherList()
        {
            List<Teacher> lstTeacher = new List<Teacher>();

            using (con)
            {
                SqlCommand cmd = new SqlCommand("sch.TeacherList", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    Teacher teacher = new Teacher();
                    teacher.IdTeacher = Convert.ToInt32(sdr["IdTeacher"]);
                    teacher.TeacherName = sdr["TeacherName"].ToString();


                    lstTeacher.Add(teacher);

                }
                con.Close();
            }
            return lstTeacher;
        }
    }
}
