using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using GiveAid.Models;
using GiveAid.Security;

namespace GiveAid.Areas.User.Controllers
{
    [FormAuthentication(RoleId = "3")]
    public class InviteController : Controller
    {
        db_GiveAidProEntities1 db = new db_GiveAidProEntities1();
        public ActionResult Index()
        {
            ViewBag.events = db.tbl_Activity.OrderByDescending(o => o.DateTime).Take(4);
            return View();
        }
    }
}