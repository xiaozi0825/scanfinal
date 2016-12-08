using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class SearchUserData
    {
        private string GetDBConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString.ToString();
        }

        public List<Models.UserDetail> searchuserData(string UserAccount)
        {
            DataTable dt = new DataTable();
            string sql = @"select * from dbo.UserDetail where UserAccount=@UserAccount";


            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@UserAccount", UserAccount));
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
                    UserAccount = row["UserAccount"].ToString(),
                    UserPassword = row["UserPassword"].ToString(),
                    UserName = row["UserName"].ToString(),
                    UserSex = (int)row["UserSex"],
                    UserEmail= row["UserEmail"].ToString(),
                });
            }
            return result;
        }

        public void UpdateUserData(Models.UserDetail User)
        {
            string sql = @" Update dbo.UserDetail
                            SET UserPassword=@UserPassword,UserName=@UserName,UserSex=@UserSex,UserEmail=@UserEmail
                            Where UserAccount=@UserAccount
						 ";


            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@UserAccount", User.UserAccount));
                cmd.Parameters.Add(new SqlParameter("@UserPassword", User.UserPassword));
                cmd.Parameters.Add(new SqlParameter("@UserName", User.UserName));
                cmd.Parameters.Add(new SqlParameter("@UserSex", User.UserSex));
                cmd.Parameters.Add(new SqlParameter("@UserEmail", User.UserEmail));

                cmd.ExecuteNonQuery();


                conn.Close();
            }

        }
    }
}