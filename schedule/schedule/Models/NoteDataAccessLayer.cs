using System.Data.SqlClient;

namespace schedule.Models
{
    public class NoteDataAccessLayer
    {
        SqlConnection con;

        public NoteDataAccessLayer()
        {
            var confoguration = GetConfiguration();
            con = new SqlConnection(confoguration.GetSection("Data").GetSection("ConnectionString").Value);
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
        public IEnumerable<Note> NoteList()
        {
            List<Note> lstNote = new List<Note>();

            using (con)
            {
                SqlCommand cmd = new SqlCommand("sch.NoteList", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    Note note = new Note();
                    note.IdNote = Convert.ToInt32(sdr["IdNote"]);
                    note.NoteName = sdr["NoteName"].ToString();
                    note.NoteText = sdr["NoteText"].ToString();

                    lstNote.Add(note);

                }
                con.Close();
            }
            return lstNote;
        }
    }
}
