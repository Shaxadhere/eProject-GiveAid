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
    public class OurAchievementsController : Controller
    {
        private db_GiveAidProEntities1 db = new db_GiveAidProEntities1();

        public async Task<ActionResult> Index()
        {
            return View(await db.tbl_OurAchievements.Where(w => w.Deleted == false).ToListAsync());
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_OurAchievements tbl_OurAchievements = await db.tbl_OurAchievements.FindAsync(id);
            if (tbl_OurAchievements == null)
            {
                return HttpNotFound();
            }
            return View(tbl_OurAchievements);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(HttpPostedFileBase file, tbl_OurAchievements tbl_OurAchievements)
        {
            if (file != null)
            {
                Random rd = new Random();
                int rdnum = rd.Next();
                string path = Server.MapPath("~/Templates/Frontend/img/");
                string filename = rdnum + file.FileName;
                string fullpath = Path.Combine(path, filename);
                file.SaveAs(fullpath);
                tbl_OurAchievements.Picture = rdnum + file.FileName;
            }

            tbl_OurAchievements.DateTime = DateTime.Now;
            tbl_OurAchievements.Active = true;
            tbl_OurAchievements.Deleted = false;

            try
            {
                if (ModelState.IsValid)
                {
                    db.tbl_OurAchievements.Add(tbl_OurAchievements);
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
                return Json(new { success = false, model = View(tbl_OurAchievements) });
            }
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_OurAchievements tbl_OurAchievements = await db.tbl_OurAchievements.FindAsync(id);
            if (tbl_OurAchievements == null)
            {
                return HttpNotFound();
            }
            return View(tbl_OurAchievements);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(tbl_OurAchievements tbl_OurAchievements, HttpPostedFileBase file)
        {
            if (file != null)
            {
                Random rd = new Random();
                int rdnum = rd.Next();
                string path = Server.MapPath("~/Templates/Frontend/img/");
                string filename = rdnum + file.FileName;
                string fullpath = Path.Combine(path, filename);
                file.SaveAs(fullpath);
                tbl_OurAchievements.Picture = rdnum + file.FileName;
            }

            tbl_OurAchievements.DateTime = DateTime.Now;
            tbl_OurAchievements.Active = true;
            tbl_OurAchievements.Deleted = false;

            try
            {
                if (ModelState.IsValid)
                {
                    if (file == null)
                    {
                        db.Entry(tbl_OurAchievements).State = EntityState.Modified;
                        db.Entry(tbl_OurAchievements).Property("Picture").IsModified = false;
                        await db.SaveChangesAsync();
                        return Json(new { success = true });
                    }
                    else
                    {
                        db.Entry(tbl_OurAchievements).State = EntityState.Modified;
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
                return Json(new { success = false, model = View(tbl_OurAchievements) });
            }
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_OurAchievements tbl_OurAchievements = await db.tbl_OurAchievements.FindAsync(id);
            if (tbl_OurAchievements == null)
            {
                return HttpNotFound();
            }
            return View(tbl_OurAchievements);
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tbl_OurAchievements tbl_OurAchievements = await db.tbl_OurAchievements.FindAsync(id);

            tbl_OurAchievements.Active = false;
            tbl_OurAchievements.Deleted = true;
            tbl_OurAchievements.DateTime = DateTime.Now;

            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(tbl_OurAchievements).State = EntityState.Modified;
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
            return View(await db.tbl_OurAchievements.Where(w => w.Deleted == true).ToListAsync());
        }

        public async Task<ActionResult> DetailsFromTrash(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_OurAchievements tbl_OurAchievements = await db.tbl_OurAchievements.FindAsync(id);
            if (tbl_OurAchievements == null)
            {
                return HttpNotFound();
            }
            return View(tbl_OurAchievements);
        }

        public async Task<ActionResult> DeleteFromTrash(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_OurAchievements tbl_OurAchievements = await db.tbl_OurAchievements.FindAsync(id);
            if (tbl_OurAchievements == null)
            {
                return HttpNotFound();
            }
            return View(tbl_OurAchievements);
        }


        [HttpPost, ActionName("DeleteFromTrash"), ValidateAntiForgeryToken]
        public async Task<ActionResult> ConfirmDeleteFromTrash(int id)
        {
            try
            {
                tbl_OurAchievements tbl_OurAchievements = await db.tbl_OurAchievements.FindAsync(id);
                db.tbl_OurAchievements.Remove(tbl_OurAchievements);
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
