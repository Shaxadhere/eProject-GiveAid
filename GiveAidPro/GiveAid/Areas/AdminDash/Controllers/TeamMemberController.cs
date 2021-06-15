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
using System.IO;
using GiveAid.Security;

namespace GiveAid.Areas.AdminDash.Controllers
{
    [FormAuthentication(RoleId = "1")]
    public class TeamMemberController : Controller
    {
        private db_GiveAidProEntities1 db = new db_GiveAidProEntities1();

        public async Task<ActionResult> Index()
        {
            var tbl_TeamMember = db.tbl_TeamMember.Include(t => t.tbl_Position);
            return View(await tbl_TeamMember.Where(w => w.Deleted == false).ToListAsync());
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_TeamMember tbl_TeamMember = await db.tbl_TeamMember.FindAsync(id);
            if (tbl_TeamMember == null)
            {
                return HttpNotFound();
            }
            return View(tbl_TeamMember);
        }

        public ActionResult Create()
        {
            ViewBag.FK_Position = new SelectList(db.tbl_Position, "PK_ID", "PositionName");
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(HttpPostedFileBase file, tbl_TeamMember tbl_TeamMember)
        {
            if (file != null)
            {
                Random rd = new Random();
                int rdnum = rd.Next();
                string path = Server.MapPath("~/Templates/Frontend/img/");
                string filename = rdnum + file.FileName;
                string fullpath = Path.Combine(path, filename);
                file.SaveAs(fullpath);
                tbl_TeamMember.Picture = rdnum + file.FileName;
            }

            tbl_TeamMember.Active = true;
            tbl_TeamMember.Deleted = false;

            try
            {
                if (ModelState.IsValid)
                {
                    db.tbl_TeamMember.Add(tbl_TeamMember);
                    await db.SaveChangesAsync();
                    return Json(new { success = true });
                }
                else
                {
                    ViewBag.FK_Position = new SelectList(db.tbl_Position, "PK_ID", "PositionName", tbl_TeamMember.FK_Position);
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
                return Json(new { success = false, model = View(tbl_TeamMember) });
            }
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_TeamMember tbl_TeamMember = await db.tbl_TeamMember.FindAsync(id);
            if (tbl_TeamMember == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_Position = new SelectList(db.tbl_Position, "PK_ID", "PositionName", tbl_TeamMember.FK_Position);
            return View(tbl_TeamMember);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(tbl_TeamMember tbl_TeamMember, HttpPostedFileBase file)
        {
            if (file != null)
            {
                Random rd = new Random();
                int rdnum = rd.Next();
                string path = Server.MapPath("~/Templates/Frontend/img/");
                string filename = rdnum + file.FileName;
                string fullpath = Path.Combine(path, filename);
                file.SaveAs(fullpath);
                tbl_TeamMember.Picture = rdnum + file.FileName;
            }

            tbl_TeamMember.Active = true;
            tbl_TeamMember.Deleted = false;

            try
            {
                if (ModelState.IsValid)
                {
                    if (file == null)
                    {
                        db.Entry(tbl_TeamMember).State = EntityState.Modified;
                        db.Entry(tbl_TeamMember).Property(p => p.Picture).IsModified = false;
                        await db.SaveChangesAsync();
                        return Json(new { success = true });
                    }
                    else
                    {
                        db.Entry(tbl_TeamMember).State = EntityState.Modified;
                        await db.SaveChangesAsync();
                        return Json(new { success = true });
                    }
                }
                else
                {
                    ViewBag.FK_Position = new SelectList(db.tbl_Position, "PK_ID", "PositionName", tbl_TeamMember.FK_Position);
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
                return Json(new { success = false, model = View(tbl_TeamMember) });
            }
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_TeamMember tbl_TeamMember = await db.tbl_TeamMember.FindAsync(id);
            if (tbl_TeamMember == null)
            {
                return HttpNotFound();
            }
            return View(tbl_TeamMember);
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tbl_TeamMember tbl_TeamMember = await db.tbl_TeamMember.FindAsync(id);

            tbl_TeamMember.Active = false;
            tbl_TeamMember.Deleted = true;

            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(tbl_TeamMember).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return Json(new { success = true });
                }
                return Json(new { success = false });
            }
            catch
            {
                return Json(new { success = false });
            }
        }

        public async Task<ActionResult> TrashBox()
        {
            return View(await db.tbl_TeamMember.Where(w => w.Deleted == true).ToListAsync());
        }

        public async Task<ActionResult> DetailsFromTrash(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_TeamMember tbl_TeamMember = await db.tbl_TeamMember.FindAsync(id);
            if (tbl_TeamMember == null)
            {
                return HttpNotFound();
            }
            return View(tbl_TeamMember);
        }

        public async Task<ActionResult> DeleteFromTrash(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_TeamMember tbl_TeamMember = await db.tbl_TeamMember.FindAsync(id);
            if (tbl_TeamMember == null)
            {
                return HttpNotFound();
            }
            return View(tbl_TeamMember);
        }


        [HttpPost, ActionName("DeleteFromTrash"), ValidateAntiForgeryToken]
        public async Task<ActionResult> ConfirmDeleteFromTrash(int id)
        {
            try
            {
                tbl_TeamMember tbl_TeamMember = await db.tbl_TeamMember.FindAsync(id);
                db.tbl_TeamMember.Remove(tbl_TeamMember);
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
