using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PracticaNETRoP.Models;
using System.Web;
using System.Web.Mvc;


namespace PracticaNETRoP.Controllers
{
    public class ProductsController : Controller
    {
        private shoopbooksEntities db = new shoopbooksEntities();

        private const int PRODUCT_WITHOUT_STOCK = 2;

        // GET: Products
        public ActionResult Products()
        {
            return View(db.Products.ToList());
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

    }

}