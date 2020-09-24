using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Store.Entities;
using System.Threading.Tasks;

namespace Store.Abstract
{
    public interface ICollectionRepository
    {
        IEnumerable<Collection> Collections { get; }
        void SaveCollection(Collection collection);
        Collection DeleteCollection(int CollectionId);
    }
}
