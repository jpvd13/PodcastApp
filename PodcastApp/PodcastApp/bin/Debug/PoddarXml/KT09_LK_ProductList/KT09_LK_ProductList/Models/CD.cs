using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KT09_LK_ProductList.Models {
    public class CD : Product {
        public string Artist { get; set; }
        public int LengthInMinutes { get; set; }

        public override ListViewItem ToListViewItem() {
            var listViewItem = new ListViewItem(new[] {
                Title,
                Price.ToString("C"),
                string.Format(
                    "Artist: {0} ({1} minutes)",
                    Artist, LengthInMinutes
                )
            });

            return listViewItem;
        }
    }
}
