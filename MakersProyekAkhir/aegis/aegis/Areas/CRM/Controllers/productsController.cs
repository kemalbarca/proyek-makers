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
    public class productsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET:
        public JsonResult masters()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var products = from p in db.products.Include(p => p.producttype)
                           select new ProductView
                           {
                               productId = p.productId,
                               code = p.code,
                               name = p.name,
                               description = p.description,
                               costprice = p.costprice,
                               salesprice = p.salesprice,
                               producttypeId = p.producttypeId,
                               nametypeproduct = p.producttype.name
                           };
            return Json(products.ToList(), JsonRequestBehavior.AllowGet);
        }






        




        // GET: /CRM/products/
        public ActionResult Index()
        {
            var products = db.products.Include(p => p.producttype);
            return View(products.ToList());
        }

        // GET: /CRM/products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: /CRM/products/Create
        public ActionResult Create()
        {
            ViewBag.producttypeIdList = new SelectList(db.producttypes, "producttypeId", "name");
            return View();
        }

        // POST: /CRM/products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="productId,code,name,description,costprice,salesprice,producttypeId")] product product)
        {
            if (ModelState.IsValid)
            {
                db.products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.producttypeIdList = new SelectList(db.producttypes, "producttypeId", "name", product.producttypeId);
            return View(product);
        }

        // GET: /CRM/products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.producttypeIdList = new SelectList(db.producttypes, "producttypeId", "name", product.producttypeId);
            return View(product);
        }

        // POST: /CRM/products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="productId,code,name,description,costprice,salesprice,producttypeId")] product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.producttypeIdList = new SelectList(db.producttypes, "producttypeId", "name", product.producttypeId);
            return View(product);
        }

        // GET: /CRM/products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: /CRM/products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            product product = db.products.Find(id);
            db.products.Remove(product);
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

public class ProductView
{
    public int productId { get; set; }
    public string code { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public decimal costprice { get; set; }
    public decimal salesprice { get; set; }
    public int producttypeId { get; set; }
    public string nametypeproduct { get; set; }
}
