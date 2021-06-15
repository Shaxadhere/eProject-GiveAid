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
    public class NGOController : Controller
    {
        private db_GiveAidProEntities1 db = new db_GiveAidProEntities1();

        public async Task<ActionResult> Index()
        {
            var tbl_NGO = db.tbl_NGO.Include(t => t.tbl_DonationCause);
            return View(await tbl_NGO.Where(w => w.Deleted == false).ToListAsync());
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_NGO tbl_NGO = await db.tbl_NGO.FindAsync(id);
            if (tbl_NGO == null)
            {
                return HttpNotFound();
            }
            return View(tbl_NGO);
        }

        public ActionResult Create()
        {
            ViewBag.causes = db.tbl_DonationCause.ToList();
            ViewBag.Fk_DonationCause = new SelectList(db.tbl_DonationCause, "PK_ID", "DonationCauseName");
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(tbl_NGO tbl_NGO, HttpPostedFileBase Logo, string selectedcauses)
        {
            string[] arr = selectedcauses.Split(',');
            if (Logo != null)
            {
                Random rd = new Random();
                int rdnum = rd.Next();
                string path = Server.MapPath("~/Templates/Frontend/img/");
                string filename = rdnum + Logo.FileName;
                string fullpath = Path.Combine(path, filename);
                Logo.SaveAs(fullpath);
                tbl_NGO.Logo = rdnum + Logo.FileName;
            }


            tbl_NGO.Active = true;
            tbl_NGO.Deleted = false;

            try
            {
                if (ModelState.IsValid)
                {
                    if (db.tbl_NGO.Any(o => o.Phone == tbl_NGO.Phone))
                    {
                        return Json(new { success = false,errors= "<ul><li>This Phone is already in regitered</li></ul>" });
                    }

                    db.tbl_NGO.Add(tbl_NGO);
                    await db.SaveChangesAsync();

                    foreach (var item in arr)
                    {
                        int causeid = Convert.ToInt32(item);
                        tbl_DonationCauseNGO dcngo = new tbl_DonationCauseNGO()
                        {
                            FK_NGO = tbl_NGO.PK_ID,
                            Active = true,
                            Deleted = false,
                            FK_DonationCause = causeid
                        };
                        db.tbl_DonationCauseNGO.Add(dcngo);
                        db.SaveChanges();
                    }
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
                    ViewBag.Fk_DonationCause = new SelectList(db.tbl_DonationCause, "PK_ID", "DonationCauseName", tbl_NGO.Fk_DonationCause);
                    return Json(new { success = false, errors = errorsList });
                }
            }
            catch(Exception e)
            {
                return Json(new { success = false, model = View(tbl_NGO) });
            }
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_NGO tbl_NGO = await db.tbl_NGO.FindAsync(id);
            if (tbl_NGO == null)
            {
                return HttpNotFound();
            }
            ViewBag.causes = db.tbl_DonationCause.ToList();
            ViewBag.Fk_DonationCause = new SelectList(db.tbl_DonationCause, "PK_ID", "DonationCauseName");
            return View(tbl_NGO);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(tbl_NGO tbl_NGO, HttpPostedFileBase Logo, string selectedcauses)
        {
            string[] arr = selectedcauses.Split(',');
            if (Logo != null)
            {
                Random rd = new Random();
                int rdnum = rd.Next();
                string path = Server.MapPath("~/Templates/Frontend/img/");
                string filename = rdnum + Logo.FileName;
                string fullpath = Path.Combine(path, filename);
                Logo.SaveAs(fullpath);
                tbl_NGO.Logo = rdnum + Logo.FileName;
            }


            tbl_NGO.Active = true;
            tbl_NGO.Deleted = false;

            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(tbl_NGO).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    var prevcauses = db.tbl_DonationCauseNGO.Where(w => w.FK_NGO == tbl_NGO.PK_ID).ToList();
                    foreach (var item in prevcauses)
                    {
                        db.tbl_DonationCauseNGO.Remove(item);
                    }

                    db.SaveChanges();

                    foreach (var item in arr)
                    {
                        int causeid = Convert.ToInt32(item);
                        tbl_DonationCauseNGO dcngo = new tbl_DonationCauseNGO()
                        {
                            FK_NGO = tbl_NGO.PK_ID,
                            Active = true,
                            Deleted = false,
                            FK_DonationCause = causeid
                        };
                        db.tbl_DonationCauseNGO.Add(dcngo);
                        db.SaveChanges();
                    }
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
                    ViewBag.Fk_DonationCause = new SelectList(db.tbl_DonationCause, "PK_ID", "DonationCauseName", tbl_NGO.Fk_DonationCause);
                    return Json(new { success = false, errors = errorsList });
                }
            }
            catch
            {
                return Json(new { success = false, model = View(tbl_NGO) });
            }
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_NGO tbl_NGO = await db.tbl_NGO.FindAsync(id);
            if (tbl_NGO == null)
            {
                return HttpNotFound();
            }
            return View(tbl_NGO);
        }
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tbl_NGO tbl_NGO = await db.tbl_NGO.FindAsync(id);

            tbl_NGO.Active = false;
            tbl_NGO.Deleted = true;

            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(tbl_NGO).State = EntityState.Modified;
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
            return View(await db.tbl_NGO.Where(w => w.Deleted == true).ToListAsync());
        }

        public async Task<ActionResult> DetailsFromTrash(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_NGO tbl_NGO = await db.tbl_NGO.FindAsync(id);
            if (tbl_NGO == null)
            {
                return HttpNotFound();
            }
            return View(tbl_NGO);
        }
        public async Task<ActionResult> Restore(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_NGO tbl_NGO = await db.tbl_NGO.FindAsync(id);
            if (tbl_NGO == null)
            {
                return HttpNotFound();
            }
            return View(tbl_NGO);
        }

        public async Task<ActionResult> DeleteFromTrash(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_NGO tbl_NGO = await db.tbl_NGO.FindAsync(id);
            if (tbl_NGO == null)
            {
                return HttpNotFound();
            }
            return View(tbl_NGO);
        }


        [HttpPost, ActionName("DeleteFromTrash"), ValidateAntiForgeryToken]
        public async Task<ActionResult> ConfirmDeleteFromTrash(int id)
        {
            try
            {
                tbl_NGO tbl_NGO = await db.tbl_NGO.FindAsync(id);
                db.tbl_NGO.Remove(tbl_NGO);
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
