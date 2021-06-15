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
    public class ActivityController : Controller
    {
        private db_GiveAidProEntities1 db = new db_GiveAidProEntities1();

        public async Task<ActionResult> Index()
        {
            return View(await db.tbl_Activity.Where(w => w.Deleted == false).ToListAsync());
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Activity tbl_Activity = await db.tbl_Activity.FindAsync(id);
            if (tbl_Activity == null)
            {
                return HttpNotFound();
            }
            var hh = db.tbl_DonationCauseNGO.Where(w => w.FK_NGO == id).ToListAsync();
            ViewBag.a = hh;
            return View(tbl_Activity);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(tbl_Activity tbl_Activity, HttpPostedFileBase file)
        {
            if (file != null)
            {
                Random rd = new Random();
                int rdnum = rd.Next();
                string path = Server.MapPath("~/Templates/Frontend/img/");
                string filename = rdnum + file.FileName;
                string fullpath = Path.Combine(path, filename);
                file.SaveAs(fullpath);
                tbl_Activity.Picture = rdnum + file.FileName;

            }
            tbl_Activity.Active = true;
            tbl_Activity.Deleted = false;
            


            try
            {
                if(tbl_Activity.DateTime==null)
                {
                    ModelState.AddModelError("DateTime","Date Time field is required!");
                }

                if (ModelState.IsValid)
                {
                    db.tbl_Activity.Add(tbl_Activity);
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
                return Json(new { success = false, model = View(tbl_Activity) });
            }

        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Activity tbl_Activity = await db.tbl_Activity.FindAsync(id);
            if (tbl_Activity == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Activity);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(tbl_Activity tbl_Activity,HttpPostedFileBase file)
        {
            if (file != null)
            {
                Random rd = new Random();
                int rdnum = rd.Next();
                string path = Server.MapPath("~/Templates/Frontend/img/");
                string filename = rdnum + file.FileName;
                string fullpath = Path.Combine(path, filename);
                file.SaveAs(fullpath);
                tbl_Activity.Picture = rdnum + file.FileName;
            }


            tbl_Activity.Active = true;
            tbl_Activity.Deleted = false;
            try
            {
                if (ModelState.IsValid)
                {
                    if (tbl_Activity.DateTime == null && file == null)
                    {
                        db.Entry(tbl_Activity).State = EntityState.Modified;
                        db.Entry(tbl_Activity).Property("Picture").IsModified = false;
                        db.Entry(tbl_Activity).Property(x => x.DateTime).IsModified = false;
                        await db.SaveChangesAsync();
                        return Json(new { success = true });
                    }
                    else if (file == null)
                    {
                        db.Entry(tbl_Activity).State = EntityState.Modified;
                        db.Entry(tbl_Activity).Property("Picture").IsModified = false;
                        await db.SaveChangesAsync();
                        return Json(new { success = true });
                    }
                    else if (tbl_Activity.DateTime == null)
                    {
                        db.Entry(tbl_Activity).State = EntityState.Modified;
                        db.Entry(tbl_Activity).Property(x => x.DateTime).IsModified = false;
                        await db.SaveChangesAsync();
                        return Json(new { success = true });
                    }
                    else
                    {
                        db.Entry(tbl_Activity).State = EntityState.Modified;
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
                return Json(new { success = false, model = View(tbl_Activity) });
            }
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Activity tbl_Activity = await db.tbl_Activity.FindAsync(id);
            if (tbl_Activity == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Activity);
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tbl_Activity tbl_Activity = await db.tbl_Activity.FindAsync(id);

            tbl_Activity.Active = false;
            tbl_Activity.Deleted = true;
            tbl_Activity.DateTime = DateTime.Now;

            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(tbl_Activity).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false });
                }
            }
            catch
            {
                return Json(new { success = false });
            }
        }

        public async Task<ActionResult> TrashBox()
        {
            return View(await db.tbl_Activity.Where(w => w.Deleted == true).ToListAsync());
        }

        public async Task<ActionResult> DetailsFromTrash(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Activity tbl_Activity = await db.tbl_Activity.FindAsync(id);
            if (tbl_Activity == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Activity);
        }
        public async Task<ActionResult> Restore(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Activity tbl_Activity = await db.tbl_Activity.FindAsync(id);
            if (tbl_Activity == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Activity);
        }

        public async Task<ActionResult> DeleteFromTrash(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Activity tbl_Activity = await db.tbl_Activity.FindAsync(id);
            if (tbl_Activity == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Activity);
        }


        [HttpPost, ActionName("DeleteFromTrash"), ValidateAntiForgeryToken]
        public async Task<ActionResult> ConfirmDeleteFromTrash(int id)
        {
            try
            {
                tbl_Activity tbl_Activity = await db.tbl_Activity.FindAsync(id);
                db.tbl_Activity.Remove(tbl_Activity);
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
