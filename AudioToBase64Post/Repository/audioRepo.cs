using AudioToBase64Post.Model;
using System.Data;
using System.Data.SqlClient;

namespace AudioToBase64Post.Repository
{
    public class audioRepo
    {
        private readonly IConfiguration _configuration;
        private SqlConnection connection;

        public audioRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Connect()
        {

            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            connection = new SqlConnection(connectionString);
        }
        public string PostAudio(Class model)
        {

            string audioString = null;
            
                Connect();
                SqlCommand cmd = new SqlCommand("SelectEmp", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email", model.Email);
                cmd.Parameters.AddWithValue("@EmployeeId", model.EmployeeID);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            audioString = reader.GetString(0);
                        }
                    }

                }
                if (audioString != null)
                {
                    string checkstring = audioString.Substring(0, 3);

                    if (checkstring == model.File.Substring(0, 3))
                    {
                        return "Success";
                    }


                }
                else
                {
                    SqlCommand cmdinsert = new SqlCommand("insertvalue", connection);
                    cmdinsert.CommandType = CommandType.StoredProcedure;
                    cmdinsert.Parameters.AddWithValue("@email", model.Email);
                    cmdinsert.Parameters.AddWithValue("@Employeeid", model.EmployeeID);
                    cmdinsert.Parameters.AddWithValue("@audio", model.File);
                    int result = cmdinsert.ExecuteNonQuery();
                    return "Success";

            }
                connection.Close();
                return "Fail";

            }
        

    }
}
