using System.Collections.Generic;
using System.Linq;
using BitCrunch.Models;

namespace BitCrunch.Repositories
{
    public class MockItemRepository : IItemRepository
    {
        public List<Item> mockItems;
        public MockItemRepository()
        {
            mockItems = new List<Item>
            {
                new Item { ItemID = 1, ItemName = "Zelda: Ocarina of Time", Description = "Original issue version for N64 in good condition", Quantity = 15, StoreName = "Dungeon Crawlers", Console = "Nintendo 64", Price = 45.99 }
            };
        }
        public Item CreateItem(Item newItem)
        {
            var maxID = mockItems.Select(m =>  m.ItemID).DefaultIfEmpty().DefaultIfEmpty().Max();
            newItem.ItemID = maxID + 1;
            mockItems.Add(newItem);
            return newItem;
        }

        public void DeleteItem(int ItemId)
        {
            var item = mockItems.FirstOrDefault(m => m.ItemID == ItemId);
            if (item != null)
            {
                mockItems.Remove(item);
            }
        }

        public Item GetItemById(int ItemId)
        {
            return mockItems.FirstOrDefault(m => m.ItemID == ItemId);
        }

        public IEnumerable<Item> GetItems()
        {
            return mockItems;
        }

        public IEnumerable<Item> GetItemsByName(string itemName)
        {
            return mockItems.Where(m => m.ItemName.Contains(itemName));
        }

        public IEnumerable<Item> GetItemsByStoreName(string storeName)
        {
            return mockItems.Where(m => m.StoreName.Contains(storeName));
        }

        public Item UpdateItem(Item newItem)
        {
            var item = mockItems.FirstOrDefault(m => m.ItemID == newItem.ItemID);
            if (item != null)
            {
                item.ItemName = newItem.ItemName;
                item.Description = newItem.Description;
                item.Quantity = newItem.Quantity;
                item.Console = newItem.Console;
                item.Price = newItem.Price;
            }
            return item;
        }
    }
}