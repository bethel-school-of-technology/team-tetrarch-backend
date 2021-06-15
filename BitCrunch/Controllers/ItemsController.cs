using System.Collections.Generic;
using System.Net;
using BitCrunch.Models;
using BitCrunch.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BitCrunch.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase 
    {
        private readonly ILogger<ItemsController> _logger;
        private readonly IItemRepository _itemRepository;
        public ItemsController(ILogger<ItemsController> logger, IItemRepository repo )
        {
            _itemRepository = repo;
            _logger = logger;
        }
        
        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            return _itemRepository.GetItems();
        }
        [HttpGet, Route("{ItemID:int}")]
        public Item GetItemById(int itemId)
        {
            var item = _itemRepository.GetItemById(itemId);
            if (item == null)
            {
                Response.StatusCode = (int) HttpStatusCode.NotFound;return null;
            }
            return item;
        }
        [HttpGet, Route("{ItemName:string}")]
        public IEnumerable<Item> GetItemsByName(string itemName)
        {
            return _itemRepository.GetItemsByName(itemName);
        }
        [HttpGet, Route("{StoreName:string}")]
        public IEnumerable<Item> GetItemsByStoreName(string storeName)
        {
            return _itemRepository.GetItemsByStoreName(storeName);
        }
        [HttpPost]
        public Item CreateItem(Item item)
        {
            if (item == null || !ModelState.IsValid)
            {
                Response.StatusCode = (int) HttpStatusCode.BadRequest;
                return null;
            }
            var newItem = _itemRepository.CreateItem(item);
            return newItem;
        }
        [HttpPut, Route("{ItemID:int}")]
        public Item UpdateItem(Item item)
        {
            if (item == null || !ModelState.IsValid)
            {
                Response.StatusCode = (int) HttpStatusCode.BadRequest;
                return null;
            }
            var newItem = _itemRepository.UpdateItem(item);
            return newItem;
        }
        [HttpDelete, Route("{ItemID:int}")]
        public void DeleteItem(int ItemId)
        {
            _itemRepository.DeleteItem(ItemId);
            Response.StatusCode = (int) HttpStatusCode.NoContent;
        }
    }
}