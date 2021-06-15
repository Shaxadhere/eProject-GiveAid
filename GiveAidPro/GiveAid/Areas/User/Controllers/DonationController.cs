using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GiveAid.Models;
using GiveAid.Security;

namespace GiveAid.Areas.User.Controllers
{
    [FormAuthentication(RoleId = "3")]
    public class DonationController : Controller
    {
        private db_GiveAidProEntities1 db = new db_GiveAidProEntities1();

        public ActionResult Index()
        {
            try
            {
                ViewBag.events = db.tbl_Activity.OrderByDescending(o => o.DateTime).Take(4);
                var msg = TempData["done"];
                ViewBag.msg = msg;
                return View();
            }
            catch
            {
                ViewBag.msg = "Content was not loaded, have you tried refreshing the page?";
                return View();
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            try
            {
                List<tbl_NGO> NGOList = db.tbl_NGO.ToList();
                ViewBag.NGOList = new SelectList(NGOList, "PK_ID", "NGOName");

                ViewBag.FK_DonationCause = new SelectList(db.tbl_DonationCause, "PK_ID", "DonationCauseName");
                ViewBag.FK_NGO = new SelectList(db.tbl_NGO, "PK_ID", "NGOName");
                ViewBag.FK_User = new SelectList(db.tbl_User, "PK_ID", "FullName");
                return View();
            }
            catch
            {
                ViewBag.msg = "Form was not loaded correctly, have you tried checking your connection?";
                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(tbl_Donation tbl_Donation)
        {
            tbl_User user = (tbl_User)Session["User"];
            if (user == null)
            {
                user = new db_GiveAidProEntities1().tbl_User.FirstOrDefault(x => x.Email == User.Identity.Name);
            }
            tbl_Donation.FK_User = user.PK_ID;
            tbl_Donation.Amount = tbl_Donation.Amount;
            tbl_Donation.Active = true;
            tbl_Donation.Deleted = false;
            tbl_Donation.DateTime = DateTime.Now;

            try
            {
                if (ModelState.IsValid)
                {
                    db.tbl_Donation.Add(tbl_Donation);
                    await db.SaveChangesAsync();
                    TempData["done"] = "Thanks for your donation, it means a lot, Want to donate more?";
                    return RedirectToAction("Index");
                }

                ViewBag.FK_DonationCauseNGO = new SelectList(db.tbl_DonationCauseNGO, "PK_ID", "DonationCauseName", tbl_Donation.FK_DonationCause);
                ViewBag.FK_NGO = new SelectList(db.tbl_NGO, "PK_ID", "NGOName", tbl_Donation.FK_NGO);
                return View();
            }
            catch
            {
                ModelState.AddModelError("unhandled", "Oops! Donation was not sent, have you tried checking your connection?");
                return View();
            }
        }
        public JsonResult DonationCasuseRef(int FK_NGO)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var CauseList = db.tbl_DonationCauseNGO.Where(x => x.FK_NGO == FK_NGO);
            var output = from a in CauseList select new { a.FK_DonationCause, a.tbl_DonationCause.DonationCauseName };
            return Json(output, JsonRequestBehavior.AllowGet);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
