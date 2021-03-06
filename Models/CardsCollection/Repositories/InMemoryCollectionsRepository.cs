using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models.Data;

namespace Models.CardsCollection.Repositories
{
    public class InMemoryCollectionsRepository : ICollectionsRepository
    {
        private InMemoryContext context;

        public InMemoryCollectionsRepository(InMemoryContext context)
        {
            this.context = context;
        }

        public async Task<bool> FindNameAsync(string collectionName, Guid uId)
        {
            return await context.Collections
                .Where(x => x.UserId == uId)
                .AnyAsync(x => x.Name == collectionName);
        }
        
        public async Task<CardsCollection> CreateAsync(CardsCollection collectionToAdd)
        {
            var id = Guid.NewGuid();
            var collection = collectionToAdd;
            collection.Id = id;

            await context.Collections.AddAsync(collection);
            await context.SaveChangesAsync();
            return collection;
        }
        
        public async Task<CardsCollection> FindByNameAsync(string collectionName, Guid userId)
        {
            return await context.Collections
                .Where(x => x.UserId == userId)
                .FirstOrDefaultAsync(x => x.Name == collectionName);
        }
        
        public async Task UpdateAsync(CardsCollection collection)
        {
            context.Collections.Update(collection);
            await context.SaveChangesAsync();
        }

        public Task<IEnumerable<CardsCollection>> FindCollections(Guid userId)
        {
            return Task.FromResult<IEnumerable<CardsCollection>>
                (context.Collections.Where(x => x.UserId == userId));
        }
        
        public async Task<CardsCollection> PatchAsync(CardsCollection patchInfo)
        {
            var card = context.Collections.Update(patchInfo);
            await context.SaveChangesAsync();
            return card.Entity;
        }

        public async Task<bool> DeleteCollectionAsync(Guid userId, string collectionName)
        {
            var collection = await context.Collections
                .Where(x => x.UserId == userId)
                .FirstOrDefaultAsync(x => x.Name == collectionName);
            
            if (collection != null)
            {
                context.Collections.Remove(collection);
                context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}