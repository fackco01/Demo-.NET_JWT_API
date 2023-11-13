using BusinessObject.Context;
using BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class CategoryDAO
    {
        //Get Category
        public static List<Category> GetCategories()
        {
            var listCategories = new List<Category>();
            try
            {
                using (var context = new eStoreDBContext())
                {
                    listCategories = context.Categories.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listCategories;
        }

        //Save Caegory
        public static void SaveCategory(Category category)
        {
            try
            {
                using (var context = new eStoreDBContext())
                {
                    context.Categories.Add(category);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Update Category
        public static void UpdateCategory(Category category)
        {
            try
            {
                using (var context = new eStoreDBContext())
                {
                    context.Entry<Category>(category).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Delete Category
        public static void DeleteCategory(Category category)
        {
            try
            {
                using (var context = new eStoreDBContext())
                {
                    var p1 = context.Categories.FirstOrDefault(
                        c => c.CategoryId == category.CategoryId);
                    context.Categories.Remove(category);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Find Category by ID
        public static Category FindCategoryById(int CategoryID)
        {
            Category c = new Category();
            try
            {
                using (var context = new eStoreDBContext())
                {
                    c = context.Categories.SingleOrDefault(x => x.CategoryId == CategoryID);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return c;
        }
    }
}
