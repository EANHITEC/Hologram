using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hologram.Controllers
{
    public class AdminCMSController : Controller
    {
        public ActionResult Login()
        {
            return View("~/Views/AdminCMS/Login.cshtml");
        }

        public ActionResult Register()
        {
            return View("~/Views/AdminCMS/Register.cshtml");
        }

        [HttpPost]
        public ActionResult Register(string id, string password, string name, string nickname, string phoneNumber, string email)
        {
            // 데이터베이스에 저장하는 코드를 작성하세요.

            // 회원 가입 완료 후 돌아갈 페이지 리디렉션 (예: 로그인 페이지로 이동)
            return RedirectToAction("Login");
        }

    }
}