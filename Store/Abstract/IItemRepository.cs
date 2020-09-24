using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Store.Entities;
using System.Threading.Tasks;

namespace Store.Abstract
{
    public interface IItemRepository
    {
        IEnumerable<Item> Items { get; }
        void SaveItem(Item item);
        Item DeleteItem(int ItemId);
    }
}
