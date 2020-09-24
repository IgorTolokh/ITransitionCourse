using Store.Abstract;
using Store.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Concrete
{
    public class EFCollectionRepository : ICollectionRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Collection> Collections
        {
            get { return context.Collections; }
        }
        public void SaveCollection(Collection collection)
        {
            if (collection.CollectionId == 0)
                context.Collections.Add(collection);
            else
            {
                Collection dbEntry = context.Collections.Find(collection.CollectionId);
                if (dbEntry != null)
                {
                    dbEntry.Name = collection.Name;
                    dbEntry.Description = collection.Description;
                    dbEntry.Price = collection.Price;
                    dbEntry.Category = collection.Category;
                    dbEntry.ImageData = collection.ImageData;
                    dbEntry.ImageMimeType = collection.ImageMimeType;
                }
            }
            context.SaveChanges();
        }
        public Collection DeleteCollection(int collectionId)
        {
            Collection dbEntry = context.Collections.Find(collectionId);
            if (dbEntry != null)
            {
                context.Collections.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}

