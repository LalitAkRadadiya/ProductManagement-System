using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProductManagement;
using ProductManagement.Models;


namespace ProductManagement.Controllers
{
    [Authorize]
    public class ProductListDatasController : Controller
    {
        private ProductDatabaseEntities db = new ProductDatabaseEntities();

        
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Image imageModel)
        {
            string filename = DateTime.Now.ToString("yymmssfff");
            string extension = ".png";
            filename = filename + extension;
            
            return View();
        }
        // GET: ProductListDatas
        public ActionResult Index()
        {
            return View(db.ProductListDatas.ToList());
        }

        // GET: ProductListDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductListData productListData = db.ProductListDatas.Find(id);
            if (productListData == null)
            {
                return HttpNotFound();
            }
            return View(productListData);
        }

        // GET: ProductListDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductListDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Category,Price,Quantity,Short_Description,Long_Description,Small_image,Large_image")] ProductListData productListData)
        {
            if (ModelState.IsValid)
            {
                db.ProductListDatas.Add(productListData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productListData);
        }

        // GET: ProductListDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductListData productListData = db.ProductListDatas.Find(id);
            if (productListData == null)
            {
                return HttpNotFound();
            }
            return View(productListData);
        }

        // POST: ProductListDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Category,Price,Quantity,Short_Description,Long_Description,Small_image,Large_image")] ProductListData productListData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productListData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productListData);
        }

        // GET: ProductListDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductListData productListData = db.ProductListDatas.Find(id);
            if (productListData == null)
            {
                return HttpNotFound();
            }
            return View(productListData);
        }

        // POST: ProductListDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductListData productListData = db.ProductListDatas.Find(id);
            db.ProductListDatas.Remove(productListData);
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
