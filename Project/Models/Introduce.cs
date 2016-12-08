using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Introduce
    {
        private string GetDBConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString.ToString();
        }

        public void UserRegister(Models.Introduction Introduction)
        {
            string sql = @" INSERT INTO Introduction (LocationName,IntroductionContents,Lat,Lon) VALUES (@LocationName,@IntroductionContents,@Lat,@Lon)";

            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@IntroductionContents", Introduction.IntroductionContents));
                cmd.Parameters.Add(new SqlParameter("@LocationName", Introduction.LocationName));
                cmd.Parameters.Add(new SqlParameter("@Lat", Introduction.Lat));
                cmd.Parameters.Add(new SqlParameter("@Lon", Introduction.Lon));
                cmd.ExecuteNonQuery();
                conn.Close();
            }


        }

        public List<Models.Introduction> SearchIntroduction()
        {
            DataTable dt = new DataTable();
            string sql = @"select IntroductionId,LocationName,IntroductionContents,Lat,Lon from dbo.Introduction";


            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapOrderDataToList(dt);
        }

        private List<Models.Introduction> MapOrderDataToList(DataTable Account)
        {
            List<Models.Introduction> result = new List<Introduction>();


            foreach (DataRow row in Account.Rows)
            {
                result.Add(new Introduction()
                {
                    IntroductionId = (int)row["IntroductionId"],
                    LocationName = row["LocationName"].ToString(),
                    IntroductionContents = row["IntroductionContents"].ToString(),
                    Lat = row["Lat"].ToString(),
                    Lon = row["Lon"].ToString(),
                });
            }
            return result;
        }
    }
}