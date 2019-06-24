using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PracticaNETRoP.Models;
namespace PracticaNETRoP.Controllers
{
        public class CarritoController : Controller
        {
        private Models.VirtualShopEntities db = new Models.VirtualShopEntities();
        private const int PRODUCT_WITHOUT_STOCK = 2;
        // GET: ShoppingCard
        public ActionResult Index(Carrito sc)
        {
            return View(sc);
        }

        // GET: ShoppingCard/Delete/5
        public ActionResult Delete(int? id, Carrito sc)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products product = sc.Find(x => x.Id == id);
            if (product != null)
            {
                sc.Remove(product);
            }
            return RedirectToAction("Index");
        }

        public ActionResult NewOrder(Carrito sc)
        {
            Orders order = new Orders();
            decimal amount = 0;
            foreach (Products product in sc)
            {
                Products productDb = db.Products.Find(product.Id);
                // order.Products.Add(productDb);
                amount = amount + productDb.price;
                productDb.stock--;

                if (productDb.stock < PRODUCT_WITHOUT_STOCK)
                {
                    Stock stockDb = new Stock
                    {
                        idProduct = productDb.Id,
                        units = productDb.stock
                    };

                   
                    productDb.Stock1.Add(stockDb);
                    db.SaveChanges();
                }

                if (order.ProductOrder == null)
                {
                    ProductOrder productOrder = new ProductOrder
                    {
                        Orders = order,
                        Products_Id = product.Id,
                        Orders_Id = order.Id
                    };

                    order.ProductOrder.Add(productOrder);
                }
                else
                {
                    foreach (ProductOrder prodOrder in order.ProductOrder)
                    {
                        if (prodOrder.Products_Id == productDb.Id)
                        {
                            prodOrder.units++;
                        }
                    }

                    db.Entry(order).State = EntityState.Modified;
                }

                db.Entry(productDb).State = EntityState.Modified;
            }

            order.dateCreation = DateTime.Now;

            string userId = User.Identity.GetUserId();
           

             order.ClientId = Int32.Parse(User.Identity.GetUserId());
            Invoices invoice = new Invoices
            {
                dateInvoice = DateTime.Now,
                amount = amount
            };

           db.Invoices.Add(invoice);
            db.Orders.Add(order);
            db.SaveChanges();
            sc.Clear();

            return RedirectToAction("NewOrder");
        }

        public ActionResult OrderCreated()
        {
            return View();
        }
    }
    
}

