using Hologram.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hologram.Controllers
{
    public class AdminInfoCMSController : Controller
    {
        // GET: AdminInfo
        public ActionResult AdminMenu()
        {
            return View("~/Views/AdminInfoCMS/AdminInfo.cshtml");
        }

        public ActionResult AdminInfo()
        {
            var currentAdmin = new AdminInfoViewModel();
            var adminList = new List<AdminListViewModel>();

            var connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM tbl_admin";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    // cmd.ExecuteNonQuery();

                    while (reader.Read())
                    {
                        adminList.Add(new AdminListViewModel
                        {
                            No = Convert.ToInt32(reader["no"]),
                            Id = reader["id"].ToString(),
                            Password = reader["password"].ToString(),
                            Name = reader["name"].ToString(),
                            Mobile = reader["mobile"].ToString(),
                            Email = reader["email"].ToString(),
                            Memo = reader["memo"].ToString(),
                            Dept = reader["dept"].ToString(),
                            Job_Title = reader["job_title"].ToString(),
                            Reg_Date = Convert.ToDateTime(reader["reg_date"])
                        });
                    }
                }
            }

            var model = new AdminListViewModel
            {
                CurrentAdmin = currentAdmin,
                AdminList = adminList,
            };
            return View("~/Views/AdminInfoCMS/AdminInfo.cshtml", model);
        }
    }
}