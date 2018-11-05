using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KT09_LK_ProductList.Models {
    public class Book : Product {
        public string Author { get; set; }
        public int NumPages { get; set; }

        public override ListViewItem ToListViewItem() {
            var listViewItem = new ListViewItem(new [] {
                Title,
                Price.ToString("C"),
                string.Format(
                    "Author: {0} ({1} pages)",
                    Author, NumPages
                )
            });

            return listViewItem;
        }
    }
}
