using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hologram.Controllers
{
    public class AdminCMSController : Controller
    {
        #region 로그인
        public ActionResult Login()
        {
            return View("~/Views/AdminCMS/Login.cshtml");
        }

        #endregion

        #region 회원가입
        public ActionResult Register()
        {
            return View("~/Views/AdminCMS/Register.cshtml");
        }

        [HttpPost]
        public ActionResult Register(string id, string password, string name, string nickname, string mobile, string email)
        {
            var connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO tbl_user (id, password, name, nickname, mobile, email) VALUES (@id, @password, @name, @nickname, @mobile, @email)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@nickname", nickname);
                    cmd.Parameters.AddWithValue("@mobile", mobile);
                    cmd.Parameters.AddWithValue("@email", email);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            return RedirectToAction("Login");
        }
        #endregion

    }
}