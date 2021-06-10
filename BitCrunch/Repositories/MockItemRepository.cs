using System.Collections.Generic;
using BitCrunch.Models;

namespace BitCrunch.Repositories
{
    public class MockItemRepository : IItemRepository
    {
        public Item CreateItem(Item newItem)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteItem(int ItemId)
        {
            throw new System.NotImplementedException();
        }

        public Item GetItemById(int ItemId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Item> GetItems()
        {
            throw new System.NotImplementedException();
        }

        public Item UpdateItem(Item newItem)
        {
            throw new System.NotImplementedException();
        }
    }
}