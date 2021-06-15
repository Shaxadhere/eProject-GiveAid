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
    public class tbl_AboutController : Controller
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

        // GET: AdminDash/tbl_About/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminDash/tbl_About/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PK_ID,What_We_Do,Our_Mission,Career_With_Us,About_Us,Active,Deleted")] tbl_About tbl_About)
        {
            if (ModelState.IsValid)
            {
                db.tbl_About.Add(tbl_About);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tbl_About);
        }

        // GET: AdminDash/tbl_About/Edit/5
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

        // POST: AdminDash/tbl_About/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PK_ID,What_We_Do,Our_Mission,Career_With_Us,About_Us,Active,Deleted")] tbl_About tbl_About)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_About).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tbl_About);
        }

        // GET: AdminDash/tbl_About/Delete/5
        public async Task<ActionResult> Delete(int? id)
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

        // POST: AdminDash/tbl_About/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tbl_About tbl_About = await db.tbl_About.FindAsync(id);
            db.tbl_About.Remove(tbl_About);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
