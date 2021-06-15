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
using System.IO;

namespace GiveAid.Areas.AdminDash.Controllers
{
    [FormAuthentication(RoleId = "1")]
    public class DonationCauseController : Controller
    {
        private db_GiveAidProEntities1 db = new db_GiveAidProEntities1();

        public async Task<ActionResult> Index()
        {
            return View(await db.tbl_DonationCause.Where(w => w.Deleted == false).ToListAsync());
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_DonationCause tbl_DonationCause = await db.tbl_DonationCause.FindAsync(id);
            if (tbl_DonationCause == null)
            {
                return HttpNotFound();
            }
            return View(tbl_DonationCause);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(tbl_DonationCause tbl_DonationCause, HttpPostedFileBase File)
        {
            if (File != null)
            {
                Random rd = new Random();
                int rdnum = rd.Next();
                string path = Server.MapPath("~/Templates/Frontend/img/");
                string filename = rdnum + File.FileName;
                string fullpath = Path.Combine(path, filename);
                File.SaveAs(fullpath);
                tbl_DonationCause.Picture = rdnum + File.FileName;
            }

            tbl_DonationCause.Active = true;
            tbl_DonationCause.Deleted = false;

            try
            {
                if (ModelState.IsValid)
                {
                    db.tbl_DonationCause.Add(tbl_DonationCause);
                    db.SaveChanges();
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
                return Json(new { success = false, model = View(tbl_DonationCause) });
            }
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_DonationCause tbl_DonationCause = await db.tbl_DonationCause.FindAsync(id);
            if (tbl_DonationCause == null)
            {
                return HttpNotFound();
            }
            return View(tbl_DonationCause);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(HttpPostedFileBase File, tbl_DonationCause tbl_DonationCause)
        {
            Random rd = new Random();
            int rdnum = rd.Next();
            if (File != null)
            {
                string path = Server.MapPath("~/Templates/Frontend/img/");
                string filename = rdnum + File.FileName;
                string fullpath = Path.Combine(path, filename);
                File.SaveAs(fullpath);
                tbl_DonationCause.Picture = rdnum + File.FileName;
            }

            tbl_DonationCause.Active = true;
            tbl_DonationCause.Deleted = false;

            try
            {
                if (ModelState.IsValid)
                {
                    if (File == null)
                    {
                        db.Entry(tbl_DonationCause).State = EntityState.Modified;
                        db.Entry(tbl_DonationCause).Property("Picture").IsModified = false;
                        await db.SaveChangesAsync();
                        return Json(new { success = true });
                    }
                    else
                    {
                        db.Entry(tbl_DonationCause).State = EntityState.Modified;
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
                return Json(new { success = false, model = View(tbl_DonationCause) });
            }
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_DonationCause tbl_DonationCause = await db.tbl_DonationCause.FindAsync(id);
            if (tbl_DonationCause == null)
            {
                return HttpNotFound();
            }
            return View(tbl_DonationCause);
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tbl_DonationCause tbl_DonationCause = await db.tbl_DonationCause.FindAsync(id);

            tbl_DonationCause.Active = false;
            tbl_DonationCause.Deleted = true;

            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(tbl_DonationCause).State = EntityState.Modified;
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
            return View(await db.tbl_DonationCause.Where(w => w.Deleted == true).ToListAsync());
        }

        public async Task<ActionResult> DetailsFromTrash(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_DonationCause tbl_DonationCause = await db.tbl_DonationCause.FindAsync(id);
            if (tbl_DonationCause == null)
            {
                return HttpNotFound();
            }
            return View(tbl_DonationCause);
        }

        public async Task<ActionResult> DeleteFromTrash(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_DonationCause tbl_DonationCause = await db.tbl_DonationCause.FindAsync(id);
            if (tbl_DonationCause == null)
            {
                return HttpNotFound();
            }
            return View(tbl_DonationCause);
        }


        [HttpPost, ActionName("DeleteFromTrash"), ValidateAntiForgeryToken]
        public async Task<ActionResult> ConfirmDeleteFromTrash(int id)
        {
            try
            {
                tbl_DonationCause tbl_DonationCause = await db.tbl_DonationCause.FindAsync(id);
                db.tbl_DonationCause.Remove(tbl_DonationCause);
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
