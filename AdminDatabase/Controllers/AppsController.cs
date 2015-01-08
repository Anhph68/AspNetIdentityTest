using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdminDatabase.Models;

namespace AdminDatabase.Controllers
{
    public class AppsController : Controller
    {
        private TDKTEntities db = new TDKTEntities();

        // GET: Apps
        public async Task<ActionResult> Index()
        {
            return View(await db.tblApps.ToListAsync());
        }

        // GET: Apps/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblApp tblApp = await db.tblApps.FindAsync(id);
            if (tblApp == null)
            {
                return HttpNotFound();
            }
            return View(tblApp);
        }

        // GET: Apps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Apps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,AppName,AppUrl,Note")] tblApp tblApp)
        {
            if (ModelState.IsValid)
            {
                db.tblApps.Add(tblApp);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tblApp);
        }

        // GET: Apps/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblApp tblApp = await db.tblApps.FindAsync(id);
            if (tblApp == null)
            {
                return HttpNotFound();
            }
            return View(tblApp);
        }

        // POST: Apps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,AppName,AppUrl,Note")] tblApp tblApp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblApp).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tblApp);
        }

        // GET: Apps/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblApp tblApp = await db.tblApps.FindAsync(id);
            if (tblApp == null)
            {
                return HttpNotFound();
            }
            return View(tblApp);
        }

        // POST: Apps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tblApp tblApp = await db.tblApps.FindAsync(id);
            db.tblApps.Remove(tblApp);
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
