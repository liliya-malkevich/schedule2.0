using System.Data.SqlClient;

namespace schedule.Models
{
    public class WeekdayDataAccessLayer
    {
        SqlConnection con;

        public WeekdayDataAccessLayer()
        {
            var confoguration = GetConfiguration();
            con = new SqlConnection(confoguration.GetSection("Data").GetSection("ConnectionString").Value);
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }

        public IEnumerable<Weekday> WeekdayList()
        {
            List<Weekday> lstWeekday = new List<Weekday>();

            using (con)
            {
                SqlCommand cmd = new SqlCommand("sch.WeekdayList", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    //Group group = new Group();
                    Weekday weekday = new Weekday();
                    weekday.IdWeekday = sdr.GetInt32(0);
                    weekday.WeekdayName = sdr.GetString(1);


                    lstWeekday.Add(weekday);

                }
                con.Close();
            }
            return lstWeekday;
        }
    }
}
