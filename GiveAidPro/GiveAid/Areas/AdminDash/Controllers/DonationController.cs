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

namespace GiveAid.Areas.AdminDash.Controllers
{
    [FormAuthentication(RoleId = "1")]
    public class DonationController : Controller
    {
        private db_GiveAidProEntities1 db = new db_GiveAidProEntities1();
        
        public async Task<ActionResult> Index()
        {
            var tbl_Donation = db.tbl_Donation.Include(t => t.tbl_DonationCause).Include(t => t.tbl_NGO).Include(t => t.tbl_User);
            return View(await tbl_Donation.Where(w=> w.Deleted == false).ToListAsync());
        }
        
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Donation tbl_Donation = await db.tbl_Donation.FindAsync(id);
            if (tbl_Donation == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Donation);
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
