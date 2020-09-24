using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Collection collection, int quantity)
        {
            CartLine line = lineCollection
                .Where(g => g.Collection.CollectionId == collection.CollectionId)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Collection = collection,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Collection collection)
        {
            lineCollection.RemoveAll(l => l.Collection.CollectionId == collection.CollectionId);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Collection.Price * e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class CartLine
    {
        public Collection Collection { get; set; }
        public int Quantity { get; set; }
    }
}
