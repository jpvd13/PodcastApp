﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
﻿using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public class CategoryHandler : XmlWriter
    {        
    {
        public List<Category> GetCategories()
        {
            XmlReader xr = new XmlReader();
            return xr.GetCategories();
        }

<<<<<<< HEAD
=======
        public int GetCategoeryId()
        {
            XmlReader xr = new XmlReader();
            return xr.GetCategoryId();
        }


>>>>>>> 9ce1e9842d45ade1c4aaa6d118afdf13029ef65a
        public override void UpdateCategory(string input, string category)
        {
            Validate val = new Validate();
            if (val.ValidateUpdateCategory(input))
            {

                XDocument doc = XDocument.Load(GetPath() + @"\Categories\Categories.xml");

                foreach (XElement element in doc.Element("Categories").Descendants())
                {
                    if (category == element.Value)
                    {
                        element.Attribute("value").Value = input;
                        element.Value = input;
                    }
                }
                doc.Save(GetPath() + @"\Categories\Categories.xml");
            } else {
            }
            else
            {
                MessageBox.Show("Invalid input", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
