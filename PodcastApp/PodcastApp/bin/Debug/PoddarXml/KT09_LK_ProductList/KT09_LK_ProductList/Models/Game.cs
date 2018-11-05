using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KT09_LK_ProductList.Models
{
    public class Game : Product
    {
        public string Platform { get; set; }

        public override ListViewItem ToListViewItem()
        {
            var listViewItem = new ListViewItem(new[] {
                Title,
                Price.ToString("C"),
                string.Format(
                    "Platform: {0}",
                    Platform
                )
            });

            return listViewItem;
        }
    }
}
