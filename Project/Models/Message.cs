using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Models
{
    public class Message
    {
        private string GetDBConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString.ToString();
        }
        /// <summary>
        /// 使用者新增介紹
        /// </summary>
        /// <param name="Intro"></param>
        /// <returns></returns>
        public int InsertIntro(Models.LocalIntroduce Intro)
        {
            int i;
            string sql = @" Insert INTO dbo.LocalIntroduce
						 (
							LocalId,UserId,IntroDetail
						 )
						VALUES
						(
							@LocalId,@UserId,@IntroDetail
                        )
						";

            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@LocalId", Intro.LocalId));
                cmd.Parameters.Add(new SqlParameter("@UserId", Intro.UserId));
                cmd.Parameters.Add(new SqlParameter("@IntroDetail",Intro.IntroDetail));
                i =cmd.ExecuteNonQuery();
                conn.Close();
            }
            return i;
        }
        /// <summary>
        /// 取得使用者的地點介紹
        /// </summary>
        /// <param name="Intro"></param>
        /// <returns></returns>
        public List<Models.LocalIntroduce> GetIntro(Models.LocalIntroduce Intro)
        {

            DataTable dt = new DataTable();
            string sql = @"Select L.UserId,IntroDetail,UserName from LocalIntroduce L JOIN UserDetail U ON L.UserId=U.UserId  Where LocalId=@LocalId";
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@LocalId", Intro.LocalId));
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapOrderDataToList(dt);

        }
        /// <summary>
        /// Mapping資料
        /// </summary>
        /// <param name="introData"></param>
        /// <returns></returns>
        private List<Models.LocalIntroduce> MapOrderDataToList(DataTable introData)
        {
            List<Models.LocalIntroduce> result = new List<LocalIntroduce>();
            foreach (DataRow row in introData.Rows)
            {
                result.Add(new LocalIntroduce()
                {
                    UserId = (int)row["UserId"],
                    IntroDetail = row["IntroDetail"].ToString(),
                    UserName = row["UserName"].ToString()
                });
            }
            return result;
        }
    }
}