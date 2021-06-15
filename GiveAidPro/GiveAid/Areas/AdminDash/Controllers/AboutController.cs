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
    public class AboutController : Controller
    {
        private db_GiveAidProEntities1 db = new db_GiveAidProEntities1();
        
        public async Task<ActionResult> Index()
        {
            return View(await db.tbl_About.ToListAsync());
        }
        
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_About tbl_About = await db.tbl_About.FindAsync(id);
            if (tbl_About == null)
            {
                return HttpNotFound();
            }
            return View(tbl_About);
        }
        
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_About tbl_About = await db.tbl_About.FindAsync(id);
            if (tbl_About == null)
            {
                return HttpNotFound();
            }
            return View(tbl_About);
        }
        
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(tbl_About tbl_About)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_About).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tbl_About);
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
