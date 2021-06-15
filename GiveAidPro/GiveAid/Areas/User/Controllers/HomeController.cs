using GiveAid.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GiveAid.Models;

namespace GiveAid.Areas.User.Controllers
{
    [FormAuthentication(RoleId = "3")]
    public class HomeController : Controller
    {
        db_GiveAidProEntities1 db = new db_GiveAidProEntities1();
        public ActionResult Index()
        {
            ViewBag.donation = db.tbl_Donation.Sum(s => s.Amount);
            return View();
        }
    }
}