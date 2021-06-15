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
    public class PartnerController : Controller
    {
        private db_GiveAidProEntities1 db = new db_GiveAidProEntities1();

        public async Task<ActionResult> Index()
        {
            return View(await db.tbl_Partner.Where(w => w.Deleted == false).ToListAsync());
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Partner tbl_Partner = await db.tbl_Partner.FindAsync(id);
            if (tbl_Partner == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Partner);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(HttpPostedFileBase file, tbl_Partner tbl_Partner)
        {
            if (file != null)
            {
                Random rd = new Random();
                int rdnum = rd.Next();
                string path = Server.MapPath("~/Templates/Frontend/img/");
                string filename = rdnum + file.FileName;
                string fullpath = Path.Combine(path, filename);
                file.SaveAs(fullpath);
                tbl_Partner.Logo = rdnum + file.FileName;
            }

            tbl_Partner.Active = true;
            tbl_Partner.Deleted = false;

            try
            {
                if (ModelState.IsValid)
                {
                    db.tbl_Partner.Add(tbl_Partner);
                    await db.SaveChangesAsync();
                    return Json(new { success = true });
                }
                else
                {
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
                return Json(new { success = false, model = View(tbl_Partner) });
            }
        }
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Partner tbl_Partner = await db.tbl_Partner.FindAsync(id);
            if (tbl_Partner == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Partner);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(tbl_Partner tbl_Partner, HttpPostedFileBase file)
        {
            if (file != null)
            {
                Random rd = new Random();
                int rdnum = rd.Next();
                string path = Server.MapPath("~/Templates/Frontend/img/");
                string filename = rdnum + file.FileName;
                string fullpath = Path.Combine(path, filename);
                file.SaveAs(fullpath);
                tbl_Partner.Logo = rdnum + file.FileName;
            }

            tbl_Partner.Active = true;
            tbl_Partner.Deleted = false;

            try
            {
                if (ModelState.IsValid)
                {
                    if (file == null)
                    {
                        db.Entry(tbl_Partner).State = EntityState.Modified;
                        db.Entry(tbl_Partner).Property("Logo").IsModified = false;
                        await db.SaveChangesAsync();
                        return Json(new { success = true });
                    }
                    else
                    {
                        db.Entry(tbl_Partner).State = EntityState.Modified;
                        await db.SaveChangesAsync();
                        return Json(new { success = true });
                    }
                }
                else
                {
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
                return Json(new { success = false, model = View(tbl_Partner) });
            }
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Partner tbl_Partner = await db.tbl_Partner.FindAsync(id);
            if (tbl_Partner == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Partner);
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tbl_Partner tbl_Partner = await db.tbl_Partner.FindAsync(id);

            tbl_Partner.Active = false;
            tbl_Partner.Deleted = true;

            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(tbl_Partner).State = EntityState.Modified;
                    db.Entry(tbl_Partner).Property(x => x.Description).IsModified = false;
                    db.Entry(tbl_Partner).Property(x => x.Logo).IsModified = false;
                    db.Entry(tbl_Partner).Property(x => x.PartnerName).IsModified = false;
                    db.Entry(tbl_Partner).Property(x => x.Website).IsModified = false;
                    await db.SaveChangesAsync();
                    return Json(new { success = true });
                }
                return Json(new { success = false });
            }
            catch
            {
                ModelState.AddModelError("unhandled", "Oops! task failed, have you tried checking your connection");
                return Json(new { success = false });
            }
        }

        public async Task<ActionResult> TrashBox()
        {
            return View(await db.tbl_Partner.Where(w => w.Deleted == true).ToListAsync());
        }

        public async Task<ActionResult> DetailsFromTrash(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Partner tbl_Partner = await db.tbl_Partner.FindAsync(id);
            if (tbl_Partner == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Partner);
        }

        public async Task<ActionResult> DeleteFromTrash(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Partner tbl_Partner = await db.tbl_Partner.FindAsync(id);
            if (tbl_Partner == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Partner);
        }


        [HttpPost, ActionName("DeleteFromTrash"), ValidateAntiForgeryToken]
        public async Task<ActionResult> ConfirmDeleteFromTrash(int id)
        {
            try
            {
                tbl_Partner tbl_Partner = await db.tbl_Partner.FindAsync(id);
                db.tbl_Partner.Remove(tbl_Partner);
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
