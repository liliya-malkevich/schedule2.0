using System.Data.SqlClient;
namespace schedule.Models
{
    //    public class GroupDataAccessLayer
    //    {
    //        string connectionString = "Data Source=(local)\\SQLEXPRESS; Database = SCHEDULE;Persist Security Info=false;User ID='sa';Password='sa';MultipleActiveResultSets=True;Trusted_Connection=False;";

    //        public IEnumerable<Schedule> GroupList()
    //        {
    //            List<Schedule> lstGroup = new List<Schedule>();

    //            using (SqlConnection con = new SqlConnection(connectionString))
    //            {
    //                SqlCommand cmd = new SqlCommand("sch.GroupList", con);
    //                cmd.CommandType = System.Data.CommandType.StoredProcedure;

    //                con.Open();
    //                SqlDataReader sdr = cmd.ExecuteReader();

    //                while (sdr.Read())
    //                {
    //                    //Group group = new Group();
    //                    Schedule sch = new Schedule();
    //                    sch.gr.IdGroup = sdr.GetInt32(0);
    //                    sch.gr.numGroup = sdr.GetString(1);
    //                    sch.gr.IdCourse = Convert.ToInt32(sdr["IdCourse"]);

    //                    lstGroup.Add(sch);

    //                }
    //                con.Close();
    //            }
    //            return lstGroup;
    //        }
    //    }
    //}

    public class GroupDataAccessLayer
    {
        string connectionString = "Data Source=(local)\\SQLEXPRESS; Database = SCHEDULE;Persist Security Info=false;User ID='sa';Password='sa';MultipleActiveResultSets=True;Trusted_Connection=False;";

        public IEnumerable<Group> GroupList()
        {
            List<Group> lstGroup = new List<Group>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sch.GroupList", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    //Group group = new Group();
                    Group sch = new Group();
                    sch.IdGroup = sdr.GetInt32(0);
                    sch.numGroup = sdr.GetString(1);
                    sch.IdCourse = Convert.ToInt32(sdr["IdCourse"]);

                    lstGroup.Add(sch);

                }
                con.Close();
            }
            return lstGroup;
        }

        public IEnumerable<Group> GroupCourseList(int courseid)
        {
            List<Group> lstGroup = new List<Group>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sch.GroupCourseList", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCourse", courseid);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    //Group group = new Group();
                    Group sch = new Group();
                    sch.IdGroup = sdr.GetInt32(0);
                    sch.numGroup = sdr.GetString(1);
            

                    lstGroup.Add(sch);

                }
                con.Close();
            }
            return lstGroup;
           

        }

    }
}
