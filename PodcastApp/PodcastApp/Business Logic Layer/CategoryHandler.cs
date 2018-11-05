using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class CategoryHandler
    {
         XmlWriter xw = new XmlWriter();
         XmlReader xr = new XmlReader();

        public  void CreateCategory(string name)
        {
            xw.WriteNewCategory(name);
        }

        public  List<Category> GetCategories()
        {
            return xr.GetCategories();
        }

        public  void CreateCategoryStorage()
        {
            xw.CreateCategoriesXml();
        }

        public int GetCategoeryId()
        {
            return xw.GetCategoryId();
        }

        public void DeleteCategory(string name)
        {
            xw.DeleteCategory(name);
        }

        public void UpdateCategory(string input, string category)
        {
            Validate val = new Validate();
            if (val.ValidateUpdateCategory(input)){                
            xw.UpdateCategory(input, category);

                //ELse felmeddelande
        }}
    }
}
