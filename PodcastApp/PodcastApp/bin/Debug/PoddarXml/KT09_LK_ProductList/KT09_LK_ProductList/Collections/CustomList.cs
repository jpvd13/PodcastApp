using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT09_LK_ProductList.Collections {
    public class CustomList<T> {
        private List<T> List { get; set; }

        public CustomList() {
            List = new List<T>();
        }

        public void Add(T item) {
            List.Add(item);
        }
        public T Get(int index) {
            return List[index];
        }
    }
}
