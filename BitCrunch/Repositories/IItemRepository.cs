using System.Collections.Generic;
using BitCrunch.Models;

namespace BitCrunch.Repositories
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetItems();
         Item GetItemById(int ItemId);
         Item CreateItem(Item newItem);
         Item UpdateItem(Item newItem);
         void DeleteItem(int ItemId);
    }
}