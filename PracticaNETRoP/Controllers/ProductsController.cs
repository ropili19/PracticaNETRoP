using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PracticaNETRoP.Models;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PracticaNETRoP.Controllers
{
    public class ProductsController : Controller
    {
        private VirtualShopEntities db = new VirtualShopEntities();

        private const int PRODUCT_WITHOUT_STOCK = 2;

        // GET: Products
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: Products
        public ActionResult Products()
        {
            return View(db.Products.ToList());
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name,price,stock,description,image,imageFile")] Products producto, HttpPostedFileBase imgFile)
        {
            if (ModelState.IsValid)
            {
                if (imgFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(imgFile.FileName);
                    string extension = Path.GetExtension(imgFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    producto.image = "/images/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/images/"), fileName);
                  
                    imgFile.SaveAs(fileName);

                
                }
                using (VirtualShopEntities db= new VirtualShopEntities()){
                    db.Products.Add(producto);
                    db.SaveChanges();
                }
              // db.Products.Add(producto);
              //  db.SaveChanges();
                ModelState.Clear();
                return RedirectToAction("Index");
            }

            return View(producto);
        }
   

      
        // Add: Products
        public ActionResult Add(Carrito sc, int id)
        {
            int numberOfProducts = 0;

            foreach (Products art in sc)
            {
                if (art.Id == id) { numberOfProducts++; }
            }

            Products product = db.Products.Find(id);
            Stock stock = db.Stock.Find(product.Id);

            if (numberOfProducts > product.stock)
            {
                TempData["notice_error"] = "No existe suficiente stock para el producto solicitado";
            }
            else
            {
                sc.Add(product);
                TempData["notice_success"] = "Se ha Añadido el artículo al carrito";
            }

            return RedirectToAction("Index");
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products producto = db.Products.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }
        // POST: Products/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,description,price,stock,image")] Products product)
        {
            if (ModelState.IsValid)
            {
                if (product != null &&  product.stock< PRODUCT_WITHOUT_STOCK)
                {
                    Stock stock = new Stock
                    {
                        idProduct = product.Id,
                        units = product.stock
                    };
                }

                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Products product = db.Products.Find(id);
            db.Products.Remove(product);
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

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }


    }
}