using BusinessObject.Context;
using BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class ProductDAO
    {
        //Get Products
        public static List<Product> GetProducts()
        {
            var listProducts = new List<Product>();
            try
            {
                using (var context = new eStoreDBContext())
                {
                    listProducts = context.Products.ToList();
                }
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }

            return listProducts;
        }

        //Find Product by ID
        public static Product FindProductById(int ProductID)
        {
            Product p = new Product();
            try
            {
                using (var context = new eStoreDBContext())
                {
                    p = context.Products.SingleOrDefault(x => x.ProductId == ProductID);
                }
            }
            catch (Exception e)
            {
                throw new Exception (e.Message);
            }
            return p;
        }

        //Save Product
        public static void SaveProduct(Product product)
        {
            try
            {
                using (var context = new eStoreDBContext())
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Update Product
        public static void UpdateProduct(Product product)
        {
            try
            {
                using (var context = new eStoreDBContext())
                {
                    context.Entry<Product>(product).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Delete Product
        public static void DeleteProduct(Product product)
        {
            try
            {
                using (var context = new eStoreDBContext())
                {
                    var p1 = context.Products.SingleOrDefault(
                        x=>x.ProductId == product.ProductId);
                    context.Products.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }
    }
}
