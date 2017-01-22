using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImmigrationApplication.Model;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ImmigrationApplication.DataAccess
{
    public class PrintRepository
    {
        private readonly immigrationEntities context = null;
        public PrintRepository()
        {
            context = new immigrationEntities();
        }
        public PrintDetails GetPersonDetailsById(int personId)
        {
            DataSet ds = new DataSet();
            PrintDetails pd = new PrintDetails();
            string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("sp_PrintDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@personid", personId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        pd.Person = new Person
                        {
                            PersonID = Convert.ToInt32(row["PersonID"]),
                            FirstName = row["FirstName"].ToString(),
                            LastName = row["LastName"].ToString()
                        };
                    }
                }
            }
            return pd;
        }
    }
}
