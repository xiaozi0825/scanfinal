using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Login
    {
        private string GetDBConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString.ToString();
        }

        public List<Models.UserDetail> SearchUser(string UserAccount,string UserPassword)
        {
            DataTable dt = new DataTable();
            string sql = @"select UserId,UserAccount,UserPassword from dbo.UserDetail where UserAccount=@UserAccount AND UserPassword=@UserPassword";


            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@UserAccount", UserAccount));
                cmd.Parameters.Add(new SqlParameter("@UserPassword", UserPassword));
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapOrderDataToList(dt);
        }

        private List<Models.UserDetail> MapOrderDataToList(DataTable Account)
        {
            List<Models.UserDetail> result = new List<UserDetail>();


            foreach (DataRow row in Account.Rows)
            {
                result.Add(new UserDetail()
                {
                    UserId = (int)row["UserId"],
                    UserAccount = row["UserAccount"].ToString(),
                    UserPassword = row["UserPassword"].ToString()
                });
            }
            return result;
        }
    }
}