using System;
using System.Data.SqlClient;
namespace schedule.Models
{
    public class SubjectDataAccessLayer
    {
        //string connectionString = "Data Source=(local)\\SQLEXPRESS; Database = SCHEDULE;Persist Security Info=false;User ID='sa';Password='sa';MultipleActiveResultSets=True;Trusted_Connection=False;";
        SqlConnection con;

        public SubjectDataAccessLayer()
        {
            var confoguration = GetConfiguration();
            con = new SqlConnection(confoguration.GetSection("Data").GetSection("ConnectionString").Value);
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
        public IEnumerable<Subject> SubjectList()
        {
            List<Subject> lstSubject = new List<Subject>();

            using (con)
            {
                SqlCommand cmd = new SqlCommand("sch.SubjectList", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    Subject subject = new Subject();
                    subject.IdSubject = Convert.ToInt32(sdr["IdSubject"]);
                    subject.SubjectName = sdr["SubjectName"].ToString();

                    lstSubject.Add(subject);

                }
                con.Close();
            }
            return lstSubject;
        }

    }
}
