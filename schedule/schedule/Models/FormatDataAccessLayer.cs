using System.Data.SqlClient;

namespace schedule.Models
{

    public class FormatDataAccessLayer
    {
        SqlConnection con;

        public FormatDataAccessLayer()
        {
            var confoguration = GetConfiguration();
            con = new SqlConnection(confoguration.GetSection("Data").GetSection("ConnectionString").Value);
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
        public IEnumerable<Format> FormatList()
        {
            List<Format> lstFormat = new List<Format>();

            using (con)
            {
                SqlCommand cmd = new SqlCommand("sch.FormatList", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    Format format = new Format();
                    format.IdFormat = Convert.ToInt32(sdr["IdFormat"]);
                    format.FormatName = sdr["FormatName"].ToString();

                    lstFormat.Add(format);

                }
                con.Close();
            }
            return lstFormat;
        }
    }

}