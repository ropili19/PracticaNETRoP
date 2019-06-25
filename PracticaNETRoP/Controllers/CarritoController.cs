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
            string userId = User.Identity.GetUserId();
            Orders order = new Orders();
            decimal amount = 0;
            order.ClientId = userId;
            order.dateCreation = DateTime.Now;
            db.Orders.Add(order);
            int idorder = db.SaveChanges();
            foreach (Products product in sc)
            {
                Products productDb = db.Products.Find(product.Id);
    
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
                   
                }

                Orders ordergen = db.Orders.Find(idorder);
                if (ordergen.ProductOrder == null)
                {
                    ProductOrder productOrder = new ProductOrder
                    {
                       
                        Products_Id = product.Id,
                        Orders_Id = idorder
                    };

                    ordergen.ProductOrder.Add(productOrder);
                    db.ProductOrder.Add(productOrder);
                    db.SaveChanges();
                }
                else
                {
                    foreach (ProductOrder prodOrder in ordergen.ProductOrder)
                    {
                        if (prodOrder.Products_Id == productDb.Id)
                        {
                            prodOrder.units++;
                        }
                    }

                     db.Entry(ordergen).State = EntityState.Modified;
                    db.SaveChanges();
                }

                 db.Entry(productDb).State = EntityState.Modified;
            }

         

          
           

           
            Invoices invoice = new Invoices();
            invoice.idClient = userId;
            invoice.idOrder = order.Id;
            invoice.amount = amount;
            invoice.dateInvoice = DateTime.Now;
            
            db.Orders.Add(order);
            db.Invoices.Add(invoice);
        
            db.SaveChanges();
            sc.Clear();

            return RedirectToAction("OrderCreated");
        }

        public ActionResult OrderCreated()
        {
            return View();
        }
    }
    
}

