using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Hologram.Controllers
{
    public class AdminCMSController : Controller
    {
        #region 로그인
        public ActionResult Login()
        {
            return View("~/Views/AdminCMS/Login.cshtml");
        }

        [HttpPost]
        public ActionResult Login(string id, string password)
        {
            var connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM tbl_admin WHERE id = @id AND password = @password";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@password", password);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            FormsAuthentication.SetAuthCookie(id, false);
                            return RedirectToAction("LoginSuccess");
                        }
                    }
                }
            }

            ModelState.AddModelError("", "아이디 또는 비밀번호가 잘못되었습니다.");
            return View("~/Views/AdminCMS/Login.cshtml");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult LoginSuccess()
        {
            return View("~/Views/AdminCMS/Dashboard.cshtml");
        }

        #endregion

        #region 회원가입
        public ActionResult Register()
        {
            return View("~/Views/AdminCMS/Register.cshtml");
        }

        [HttpPost]
        public ActionResult Register(string id, string password, string name, string mobile, string email, string dept, string job_title)
        {
            var connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO tbl_admin (id, password, name, mobile, email, dept, job_title) VALUES (@id, @password, @name, @mobile, @email, @dept, @job_title)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@mobile", mobile);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@dept", dept);
                    cmd.Parameters.AddWithValue("@job_title", job_title);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            return RedirectToAction("Login");
        }
        #endregion

        #region 디바이스

        public ActionResult Devices()
        {
            var connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT no, use_state, name, parts_code, serial_code FROM tbl_device";
                var dt = new DataTable();

                using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                {
                    con.Open();
                    da.Fill(dt);
                }

                return View("~/Views/AdminCMS/Device.cshtml", dt);
            }
        }


        #endregion

        #region 컨텐츠

        public ActionResult Content()
        {
            var connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT no, title, contents_type, convert_state1 FROM tbl_contents";
                var dt = new DataTable();

                using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                {
                    con.Open();
                    da.Fill(dt);
                }

                return View("~/Views/AdminCMS/Content.cshtml", dt);
            }
        }

        #endregion

        #region 사용자

        public ActionResult User()
        {
            var connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT no , id, name, nickname, mobile, email , reg_date FROM tbl_user";
                var dt = new DataTable();

                using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                {
                    con.Open();
                    da.Fill(dt);
                }

                return View("~/Views/AdminCMS/User.cshtml", dt);
            }
        }

        #endregion

    }
}