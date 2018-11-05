using System.Windows.Forms;
using KT09_LK_ProductList.Interfaces;

namespace KT09_LK_ProductList.Models {
    public abstract class Product : IListable {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }

        public abstract ListViewItem ToListViewItem();
    }
}
