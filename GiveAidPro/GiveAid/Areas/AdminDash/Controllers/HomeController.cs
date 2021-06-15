using GiveAid.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GiveAid.Models;

namespace GiveAid.Areas.AdminDash.Controllers
{
    [FormAuthentication(RoleId = "1")]
    public class HomeController : Controller
    {
        db_GiveAidProEntities1 db = new db_GiveAidProEntities1();
        public ActionResult Index()
        {
            ViewBag.donate = db.tbl_Donation.Take(20).ToList();
            ViewBag.donation = db.tbl_Donation.Sum(s => s.Amount).ToString();
            ViewBag.partner = db.tbl_Partner.Count();
            ViewBag.ngo = db.tbl_NGO.Count();
            ViewBag.achieve = db.tbl_OurAchievements.Count();
            ViewBag.team = db.tbl_TeamMember.Count();
            return View();
        }
        public ActionResult PopUp()
        {
            return View();
        }
        
    }
}