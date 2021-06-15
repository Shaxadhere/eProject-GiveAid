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
    public class QnAController : Controller
    {
        private db_GiveAidProEntities1 db = new db_GiveAidProEntities1();

        public async Task<ActionResult> Index()
        {
            var tbl_QnA = db.tbl_QnA.Include(t => t.tbl_User);
            return View(await tbl_QnA.Where(w => w.Answer == null && w.Deleted == false).ToListAsync());

        }
        public async Task<ActionResult> Answered()
        {
            var tbl_QnA = db.tbl_QnA.Include(t => t.tbl_User);
            return View(await tbl_QnA.Where(w => w.Answer != null && w.Deleted == false).ToListAsync());
        }
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_QnA tbl_QnA = await db.tbl_QnA.FindAsync(id);
            if (tbl_QnA == null)
            {
                return HttpNotFound();
            }
            return View(tbl_QnA);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_QnA tbl_QnA = await db.tbl_QnA.FindAsync(id);
            if (tbl_QnA == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_User = new SelectList(db.tbl_User, "PK_ID", "FullName", tbl_QnA.FK_User);
            return View(tbl_QnA);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(tbl_QnA tbl_QnA)
        {
            try
            {
                if (tbl_QnA.Answer == null)
                {
                    ModelState.AddModelError("Answer", "Answer field is required");
                }
                if (ModelState.IsValid)
                {
                    db.Entry(tbl_QnA).State = EntityState.Modified;
                    db.Entry(tbl_QnA).Property("FK_User").IsModified = false;
                    db.Entry(tbl_QnA).Property("Question").IsModified = false;
                    db.Entry(tbl_QnA).Property("Active").IsModified = false;
                    db.Entry(tbl_QnA).Property("Deleted").IsModified = false;
                    db.Entry(tbl_QnA).Property("DateTime").IsModified = false;

                    await db.SaveChangesAsync();
                    return Json(new { success = true });
                }
                else
                {
                    ViewBag.FK_User = new SelectList(db.tbl_User, "PK_ID", "FullName", tbl_QnA.FK_User);
                    string errorsList = "";
                    foreach (var item in ModelState.Values)
                    {
                        foreach (var err in item.Errors)
                        {
                            errorsList += "<li>" + err.ErrorMessage + "</li>";
                        }
                    }
                    errorsList = "<ul>" + errorsList + "</ul>";
                    return Json(new { success = false, errors = errorsList });
                }
            }
            catch
            {
                return Json(new { success = false, model = View(tbl_QnA) });
            }
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_QnA tbl_QnA = await db.tbl_QnA.FindAsync(id);
            if (tbl_QnA == null)
            {
                return HttpNotFound();
            }
            return View(tbl_QnA);
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tbl_QnA tbl_QnA = await db.tbl_QnA.FindAsync(id);
            tbl_QnA.Deleted = true;
            tbl_QnA.Active = false;
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(tbl_QnA).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return Json(new { success = true });
                }
                ViewBag.FK_User = new SelectList(db.tbl_User, "PK_ID", "FullName", tbl_QnA.FK_User);
                return Json(new { success = false });
            }
            catch
            {
                return Json(new { success = false });
            }

        }

        public async Task<ActionResult> TrashBox()
        {
            return View(await db.tbl_QnA.Where(w => w.Deleted == true).ToListAsync());
        }

        public async Task<ActionResult> DetailsFromTrash(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_QnA tbl_QnA = await db.tbl_QnA.FindAsync(id);
            if (tbl_QnA == null)
            {
                return HttpNotFound();
            }
            return View(tbl_QnA);
        }

        public async Task<ActionResult> DeleteFromTrash(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_QnA tbl_QnA = await db.tbl_QnA.FindAsync(id);
            if (tbl_QnA == null)
            {
                return HttpNotFound();
            }
            return View(tbl_QnA);
        }


        [HttpPost, ActionName("DeleteFromTrash"), ValidateAntiForgeryToken]
        public async Task<ActionResult> ConfirmDeleteFromTrash(int id)
        {
            try
            {
                tbl_QnA tbl_QnA = await db.tbl_QnA.FindAsync(id);
                db.tbl_QnA.Remove(tbl_QnA);
                await db.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
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
