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

namespace GiveAid.Areas.AdminDash.Controllers
{
    public class UserController : Controller
    {
        private db_GiveAidProEntities1 db = new db_GiveAidProEntities1();
        
        public async Task<ActionResult> Index()
        {
            var tbl_User = db.tbl_User.Include(t => t.tbl_UserType);
            return View(await tbl_User.ToListAsync());
        }
        
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_User tbl_User = await db.tbl_User.FindAsync(id);
            if (tbl_User == null)
            {
                return HttpNotFound();
            }
            return View(tbl_User);
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
