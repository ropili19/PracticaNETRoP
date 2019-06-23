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
        private Models.VirtualShopEntities db = new Models.VirtualShopEntities();

       public ActionResult Index(Carrito cc)
            {
                return View(cc);
            }
        public ActionResult OrderCreated()
        {
            return View();
        }

        /*      public ActionResult AddProducto(Carrito cc, int id)
              {
                  Products p = db.Products.Find(id);
                  cc.Add(p);

                  return RedirectToAction("Index", "Productoes");
              }*/
        // GET: Carrito
        public ActionResult Add(int id, Carrito cc)
        {
          
            Products prod = db.Products.Find(id);
            cc.Add(prod);

            //return View("Index", cc);
            return RedirectToAction("Index", "Home");
        }
    }
    
}

