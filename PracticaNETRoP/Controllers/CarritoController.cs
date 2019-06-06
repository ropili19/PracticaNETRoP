using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using PracticaNETRoP.Models;
namespace PracticaNETRoP.Controllers
{
        public class CarritoController : Controller
        {
        private Models.shoopbooksEntities db = new Models.shoopbooksEntities();

        public ActionResult Index(Carrito cc)
            {
                return View(cc);
            }


            public ActionResult AddProducto(Carrito cc, int id)
            {
                Products p = db.Products.Find(id);
                cc.Add(p);

                return RedirectToAction("Index", "Productoes");
            }
        }
    
}

