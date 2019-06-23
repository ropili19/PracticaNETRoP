using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticaNETRoP.Models
{
    public class CarritoCompraModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext,
                                ModelBindingContext bindingContext)
        {
            Carrito cc = (Carrito)controllerContext
                                .HttpContext
                                .Session["ID_CC_Productos"];

            if (cc == null)
            {
                cc = new Carrito();
                controllerContext.HttpContext
                                .Session["ID_CC_Productos"] = cc;
            }


            return cc;
        }

    }
}