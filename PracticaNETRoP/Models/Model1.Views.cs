//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Data.Entity.Infrastructure.MappingViews;

[assembly: DbMappingViewCacheTypeAttribute(
    typeof(PracticaNETRoP.Models.VirtualShopEntities),
    typeof(Edm_EntityMappingGeneratedViews.ViewsForBaseEntitySets946b647e7e2a3d8fdb2066b08f7ae49f02d4c47fc7cfcd4d7d407a5a313d9ab7))]

namespace Edm_EntityMappingGeneratedViews
{
    using System;
    using System.CodeDom.Compiler;
    using System.Data.Entity.Core.Metadata.Edm;

    /// <summary>
    /// Implements a mapping view cache.
    /// </summary>
    [GeneratedCode("Entity Framework 6 Power Tools", "0.9.2.0")]
    internal sealed class ViewsForBaseEntitySets946b647e7e2a3d8fdb2066b08f7ae49f02d4c47fc7cfcd4d7d407a5a313d9ab7 : DbMappingViewCache
    {
        /// <summary>
        /// Gets a hash value computed over the mapping closure.
        /// </summary>
        public override string MappingHashValue
        {
            get { return "946b647e7e2a3d8fdb2066b08f7ae49f02d4c47fc7cfcd4d7d407a5a313d9ab7"; }
        }

        /// <summary>
        /// Gets a view corresponding to the specified extent.
        /// </summary>
        /// <param name="extent">The extent.</param>
        /// <returns>The mapping view, or null if the extent is not associated with a mapping view.</returns>
        public override DbMappingView GetView(EntitySetBase extent)
        {
            if (extent == null)
            {
                throw new ArgumentNullException("extent");
            }

            var extentName = extent.EntityContainer.Name + "." + extent.Name;

            if (extentName == "VirtualShopModelStoreContainer.Invoices")
            {
                return GetView0();
            }

            if (extentName == "VirtualShopModelStoreContainer.Orders")
            {
                return GetView1();
            }

            if (extentName == "VirtualShopModelStoreContainer.ProductOrder")
            {
                return GetView2();
            }

            if (extentName == "VirtualShopModelStoreContainer.Products")
            {
                return GetView3();
            }

            if (extentName == "VirtualShopModelStoreContainer.Stock")
            {
                return GetView4();
            }

            if (extentName == "VirtualShopEntities.Invoices")
            {
                return GetView5();
            }

            if (extentName == "VirtualShopEntities.Orders")
            {
                return GetView6();
            }

            if (extentName == "VirtualShopEntities.ProductOrder")
            {
                return GetView7();
            }

            if (extentName == "VirtualShopEntities.Products")
            {
                return GetView8();
            }

            if (extentName == "VirtualShopEntities.Stock")
            {
                return GetView9();
            }

            return null;
        }

        /// <summary>
        /// Gets the view for VirtualShopModelStoreContainer.Invoices.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView0()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Invoices
        [VirtualShopModel.Store.Invoices](T1.Invoices_Id, T1.Invoices_amount, T1.Invoices_dateInvoice, T1.Invoices_idClient, T1.Invoices_idOrder)
    FROM (
        SELECT 
            T.Id AS Invoices_Id, 
            T.amount AS Invoices_amount, 
            T.dateInvoice AS Invoices_dateInvoice, 
            T.idClient AS Invoices_idClient, 
            T.idOrder AS Invoices_idOrder, 
            True AS _from0
        FROM VirtualShopEntities.Invoices AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for VirtualShopModelStoreContainer.Orders.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView1()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Orders
        [VirtualShopModel.Store.Orders](T1.Orders_Id, T1.Orders_ClientId, T1.Orders_dateCreation)
    FROM (
        SELECT 
            T.Id AS Orders_Id, 
            T.ClientId AS Orders_ClientId, 
            T.dateCreation AS Orders_dateCreation, 
            True AS _from0
        FROM VirtualShopEntities.Orders AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for VirtualShopModelStoreContainer.ProductOrder.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView2()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing ProductOrder
        [VirtualShopModel.Store.ProductOrder](T1.[ProductOrder.Orders_Id], T1.[ProductOrder.Products_Id], T1.ProductOrder_units, T1.ProductOrder_id)
    FROM (
        SELECT 
            T.Orders_Id AS [ProductOrder.Orders_Id], 
            T.Products_Id AS [ProductOrder.Products_Id], 
            T.units AS ProductOrder_units, 
            T.id AS ProductOrder_id, 
            True AS _from0
        FROM VirtualShopEntities.ProductOrder AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for VirtualShopModelStoreContainer.Products.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView3()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Products
        [VirtualShopModel.Store.Products](T1.Products_Id, T1.Products_price, T1.Products_image, T1.Products_name, T1.Products_description, T1.Products_stock)
    FROM (
        SELECT 
            T.Id AS Products_Id, 
            T.price AS Products_price, 
            T.image AS Products_image, 
            T.name AS Products_name, 
            T.description AS Products_description, 
            T.stock AS Products_stock, 
            True AS _from0
        FROM VirtualShopEntities.Products AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for VirtualShopModelStoreContainer.Stock.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView4()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Stock
        [VirtualShopModel.Store.Stock](T1.Stock_Id, T1.Stock_idProduct, T1.Stock_units)
    FROM (
        SELECT 
            T.Id AS Stock_Id, 
            T.idProduct AS Stock_idProduct, 
            T.units AS Stock_units, 
            True AS _from0
        FROM VirtualShopEntities.Stock AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for VirtualShopEntities.Invoices.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView5()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Invoices
        [VirtualShopModel.Invoices](T1.Invoices_Id, T1.Invoices_amount, T1.Invoices_dateInvoice, T1.Invoices_idClient, T1.Invoices_idOrder)
    FROM (
        SELECT 
            T.Id AS Invoices_Id, 
            T.amount AS Invoices_amount, 
            T.dateInvoice AS Invoices_dateInvoice, 
            T.idClient AS Invoices_idClient, 
            T.idOrder AS Invoices_idOrder, 
            True AS _from0
        FROM VirtualShopModelStoreContainer.Invoices AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for VirtualShopEntities.Orders.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView6()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Orders
        [VirtualShopModel.Orders](T1.Orders_Id, T1.Orders_ClientId, T1.Orders_dateCreation)
    FROM (
        SELECT 
            T.Id AS Orders_Id, 
            T.ClientId AS Orders_ClientId, 
            T.dateCreation AS Orders_dateCreation, 
            True AS _from0
        FROM VirtualShopModelStoreContainer.Orders AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for VirtualShopEntities.ProductOrder.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView7()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing ProductOrder
        [VirtualShopModel.ProductOrder](T1.[ProductOrder.Orders_Id], T1.[ProductOrder.Products_Id], T1.ProductOrder_units, T1.ProductOrder_id)
    FROM (
        SELECT 
            T.Orders_Id AS [ProductOrder.Orders_Id], 
            T.Products_Id AS [ProductOrder.Products_Id], 
            T.units AS ProductOrder_units, 
            T.id AS ProductOrder_id, 
            True AS _from0
        FROM VirtualShopModelStoreContainer.ProductOrder AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for VirtualShopEntities.Products.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView8()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Products
        [VirtualShopModel.Products](T1.Products_Id, T1.Products_price, T1.Products_image, T1.Products_name, T1.Products_description, T1.Products_stock)
    FROM (
        SELECT 
            T.Id AS Products_Id, 
            T.price AS Products_price, 
            T.image AS Products_image, 
            T.name AS Products_name, 
            T.description AS Products_description, 
            T.stock AS Products_stock, 
            True AS _from0
        FROM VirtualShopModelStoreContainer.Products AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for VirtualShopEntities.Stock.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView9()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Stock
        [VirtualShopModel.Stock](T1.Stock_Id, T1.Stock_idProduct, T1.Stock_units)
    FROM (
        SELECT 
            T.Id AS Stock_Id, 
            T.idProduct AS Stock_idProduct, 
            T.units AS Stock_units, 
            True AS _from0
        FROM VirtualShopModelStoreContainer.Stock AS T
    ) AS T1");
        }
    }
}
