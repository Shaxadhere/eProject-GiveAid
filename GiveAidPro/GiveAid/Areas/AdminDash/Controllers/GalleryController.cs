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
    public class GalleryController : Controller
    {
        private db_GiveAidProEntities1 db = new db_GiveAidProEntities1();

        public async Task<ActionResult> Index()
        {
            return View(await db.tbl_Gallery.Where(w => w.Deleted == false).ToListAsync());
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Gallery tbl_Gallery = await db.tbl_Gallery.FindAsync(id);
            if (tbl_Gallery == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Gallery);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(tbl_Gallery tbl_Gallery, HttpPostedFileBase file)
        {
            if (file != null)
            {
                Random rd = new Random();
                int rdnum = rd.Next();
                string path = Server.MapPath("~/Templates/Frontend/img/");
                string filename = rdnum + file.FileName;
                string fullpath = Path.Combine(path, filename);
                file.SaveAs(fullpath);
                tbl_Gallery.Picture = rdnum + file.FileName;
            }

            tbl_Gallery.Active = true;
            tbl_Gallery.Deleted = false;

            try
            {
                if (ModelState.IsValid)
                {
                    db.tbl_Gallery.Add(tbl_Gallery);
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
                return Json(new { success = false, model = View(tbl_Gallery) });
            }
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Gallery tbl_Gallery = await db.tbl_Gallery.FindAsync(id);
            if (tbl_Gallery == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Gallery);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(tbl_Gallery tbl_Gallery, HttpPostedFileBase file)
        {
            if (file != null)
            {
                Random rd = new Random();
                int rdnum = rd.Next();
                string path = Server.MapPath("~/Templates/Frontend/img/");
                string filename = rdnum + file.FileName;
                string fullpath = Path.Combine(path, filename);
                file.SaveAs(fullpath);
                tbl_Gallery.Picture = rdnum + file.FileName;
            }

            tbl_Gallery.Active = true;
            tbl_Gallery.Deleted = false;

            try
            {
                if (ModelState.IsValid)
                {
                    if (file == null)
                    {
                        db.Entry(tbl_Gallery).State = EntityState.Modified;
                        db.Entry(tbl_Gallery).Property("Picture").IsModified = false;
                        await db.SaveChangesAsync();
                        return Json(new { success = true });
                    }
                    else
                    {
                        db.Entry(tbl_Gallery).State = EntityState.Modified;
                        await db.SaveChangesAsync();
                        return Json(new { success = true });
                    }
                }
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
            catch
            {
                return Json(new { success = false, model = View(tbl_Gallery) });
            }
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Gallery tbl_Gallery = await db.tbl_Gallery.FindAsync(id);
            if (tbl_Gallery == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Gallery);
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tbl_Gallery tbl_Gallery = await db.tbl_Gallery.FindAsync(id);

            tbl_Gallery.Active = false;
            tbl_Gallery.Deleted = true;
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(tbl_Gallery).State = EntityState.Modified;
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
            return View(await db.tbl_Gallery.Where(w => w.Deleted == true).ToListAsync());
        }

        public async Task<ActionResult> DetailsFromTrash(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Gallery tbl_Gallery = await db.tbl_Gallery.FindAsync(id);
            if (tbl_Gallery == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Gallery);
        }

        public async Task<ActionResult> DeleteFromTrash(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Gallery tbl_Gallery = await db.tbl_Gallery.FindAsync(id);
            if (tbl_Gallery == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Gallery);
        }


        [HttpPost, ActionName("DeleteFromTrash"), ValidateAntiForgeryToken]
        public async Task<ActionResult> ConfirmDeleteFromTrash(int id)
        {
            try
            {
                tbl_Gallery tbl_Gallery = await db.tbl_Gallery.FindAsync(id);
                db.tbl_Gallery.Remove(tbl_Gallery);
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
