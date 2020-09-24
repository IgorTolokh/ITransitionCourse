using Store.Abstract;
using Store.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Concrete
{
    public class EFItemRepository : IItemRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Item> Items
        {
            get { return context.Items; }
        }
        public void SaveItem(Item item)
        {
            if (item.ItemId == 0)
                context.Items.Add(item);
            else
            {
                Item dbEntry = context.Items.Find(item.ItemId);
                if (dbEntry != null)
                {
                    dbEntry.Name = item.Name;
                    dbEntry.Price = item.Price;
                    dbEntry.Tag = item.Tag;
                }
            }
            context.SaveChanges();
        }
        public Item DeleteItem(int itemId)
        {
            Item dbEntry = context.Items.Find(itemId);
            if (dbEntry != null)
            {
                context.Items.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}

