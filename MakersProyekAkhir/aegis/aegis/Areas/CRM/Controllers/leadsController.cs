using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using aegis.Models;

namespace aegis.Areas.CRM.Controllers
{

    [Authorize]
    public class leadsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET:
        public JsonResult masters()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var leads = from l in db.leads.Include(l => l.organization)
                select new LeadView
                {
                    leadId = l.leadId,
                    code = l.code,
                    firstname = l.firstname,
                    lastname = l.lastname,
                    organizationId = l.organizationId,
                    rating = l.rating,
                    email = l.email,
                    phone = l.phone,
                    nameorganization = l.organization.name
                };
            return Json(db.leads.ToList(), JsonRequestBehavior.AllowGet);
        }






        




        // GET: /CRM/leads/
        public ActionResult Index()
        {
            var leads = db.leads.Include(l => l.organization);
            return View(leads.ToList());
        }

        // GET: /CRM/leads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lead lead = db.leads.Find(id);
            if (lead == null)
            {
                return HttpNotFound();
            }
            return View(lead);
        }

        // GET: /CRM/leads/Create
        public ActionResult Create()
        {
            ViewBag.organizationIdList = new SelectList(db.organizations, "organizationId", "name");
            return View();
        }

        // POST: /CRM/leads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="leadId,code,firstname,lastname,organizationId,rating,email,phone")] lead lead)
        {
            if (ModelState.IsValid)
            {
                db.leads.Add(lead);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.organizationIdList = new SelectList(db.organizations, "organizationId", "name", lead.organizationId);
            return View(lead);
        }

        // GET: /CRM/leads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lead lead = db.leads.Find(id);
            if (lead == null)
            {
                return HttpNotFound();
            }
            ViewBag.organizationIdList = new SelectList(db.organizations, "organizationId", "name", lead.organizationId);
            return View(lead);
        }

        // POST: /CRM/leads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="leadId,code,firstname,lastname,organizationId,rating,email,phone")] lead lead)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lead).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.organizationIdList = new SelectList(db.organizations, "organizationId", "name", lead.organizationId);
            return View(lead);
        }

        // GET: /CRM/leads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lead lead = db.leads.Find(id);
            if (lead == null)
            {
                return HttpNotFound();
            }
            return View(lead);
        }

        // POST: /CRM/leads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            lead lead = db.leads.Find(id);
            db.leads.Remove(lead);
            db.SaveChanges();
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

public class LeadView
{
    public int leadId { get; set; }
    public string code { get; set; }
    public string firstname { get; set; }
    public string lastname { get; set; }
    public int organizationId { get; set; }
    public int rating { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
    public string nameorganization{ get; set; }
}
