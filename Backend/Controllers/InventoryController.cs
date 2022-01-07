using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Backend.Models;
using Backend.Persistence;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    /*

    endpoints 
    POST Inventory - Creates an Inventory DONE
    POST Items(JSON) - adds multiple items 
    POST Item(Item item) - adds one item DONE 
    POST Item To inventory - Add Item to a specified Inventory
    GET Item by ID DONE
    GET all items DONE
    Edit Item by Id
    GET List of items DONE
    DELETE Inventory by id 
    DELETE Item By id 
    */

    public class InventoryController : ControllerBase
    {
        private readonly DataContext _context; 

        public InventoryController(DataContext context)
        {
            this._context = context; 
        }

        [HttpPost("addInventory")]
        public async Task<IActionResult> AddInventory([FromBody] string inventoryName)
        {
            try
            {

                if (string.IsNullOrEmpty(inventoryName))
                {
                    return BadRequest("Inventory name is null");
                }

                var inventory = await _context.Inventory.FirstOrDefaultAsync(x => x.Name.Contains(inventoryName));
                if (inventory != null)
                {
                    return BadRequest($"The inventory: {inventoryName} Already Exists");
                }

                await _context.Inventory.AddAsync(new Inventory
                {
                    Name = inventoryName
                });

                await _context.SaveChangesAsync();

                return Ok($"Inventory: {inventoryName} is created");

            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody] Item item)
        {
            try
            {
                //Check if item already exists
                var itemInDb = _context.Inventory.Include(x => x.Items).SelectMany(x => x.Items.Where(x => x.ItemName.Equals(item.ItemName)));

                if (itemInDb.SingleOrDefault(x => x.ItemName.Equals(item.ItemName)) != null)
                {
                    return BadRequest($"The item {item.ItemName} already exists in the database. Did you mean to update?\nIf yes please use the update endpoint.");
                }

                item.DateOfCreation = DateTime.Now;
                item.IsAvailable = item.QuantityStock > 0 ? true : false;
                var inventory = await _context.Inventory.Include(x => x.Items).FirstOrDefaultAsync(x => x.Name.Equals("LogisticsDefaultInventory")); //default inventory
                inventory.Items.Add(item);
                await _context.SaveChangesAsync();

                return Ok($"The item {item.ItemName} was added to the database.");

            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpPost("{inventoryName}/items")]
        public async Task<IActionResult> AddItemsListToInventory([FromBody] List<Item> items, string inventoryName){
            try{

                 if (string.IsNullOrEmpty(inventoryName)){
                     return BadRequest($"Inventory with the name is empty");
                 }

                var inventory = await _context.Inventory.Include(x => x.Items).FirstOrDefaultAsync(x => x.Name.Equals(inventoryName));
                
                if (inventory == null)
                    return BadRequest($"Inventory with the name: {inventoryName} does not exist.");

                foreach (Item item in items){
                    item.DateOfCreation = DateTime.Now;
                    item.IsAvailable = item.QuantityStock > 0 ? true : false; 
                }

                inventory.Items.AddRange(items);
                await _context.SaveChangesAsync();

                return Ok("List of items has been added to the database");


            }catch (Exception e){
                return BadRequest(e.ToString());
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemById(string id)
        {
            try
            {
                Item item = await _context.Items.FirstOrDefaultAsync(x => x.Id.Equals(new Guid(id)));

                if (item == null)
                {
                    return BadRequest($"Item with the id {id} does not exist.");
                }

                return Ok(item);
            }
            catch (Exception e)
            {
                return BadRequest($"Item with the id {id} does not exist. For a detailed error, read below.\n\n\n{e.ToString()}");
            }
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllDefaultInventoryItem()
        {
            //returns all items in default inventory
            try
            {
                var inventory = await _context.Inventory.Include(x => x.Items).FirstOrDefaultAsync(x => x.Name.Equals("LogisticsDefaultInventory")); //default inventory
                return Ok(inventory);

            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }


        [HttpGet("{name}/All")]
        public async Task<IActionResult> GetAllInventoryItemByName(string name)
        {
            //returns all items in specified inventory
            try
            {
                var inventory = await _context.Inventory.Include(x => x.Items).FirstOrDefaultAsync(x => x.Name.Equals(name));
                if (inventory == null)
                    return BadRequest($"Inventory with name: {name} does not exist");
                return Ok(inventory);

            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpGet("items/")]
        public async Task<IActionResult> GetAllDatabaseItems()
        {
            //returns all items in the database
            try
            {
            
                return Ok(await _context.Items.ToArrayAsync());

            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpPut("update/item/{id}")]
        public async Task<IActionResult> UpdateItemById(string id, [FromBody] Item updatedItem)
        {
            try
            {

                if (string.IsNullOrEmpty(id))
                    return BadRequest("Given id is empty.");

                Item oldItem = await _context.Items.FirstOrDefaultAsync(x => x.Id.Equals(new Guid(id)));
                if (oldItem == null)
                    return BadRequest("Item with the given Id does not exist");

                oldItem.ItemName = updatedItem.ItemName;
                oldItem.ItemPrice = updatedItem.ItemPrice;
                oldItem.QuantityStock = updatedItem.QuantityStock;
                oldItem.Description = updatedItem.Description;
                oldItem.IsAvailable = updatedItem.QuantityStock > 0 ? true : false;
                oldItem.DateOfCreation = DateTime.Now;

                await _context.SaveChangesAsync();

                return Ok($"The item with the id {updatedItem.Id} has been updated.");


            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemWithId(string id){

            try {

                if (string.IsNullOrEmpty(id))
                    return BadRequest("the given ID is empty");

                Item item = await _context.Items.FirstOrDefaultAsync(x => x.Id.Equals(new Guid(id)));

                if (item == null)
                    return BadRequest($"The item with the given ID: {id} does not exist");

                _context.Items.Remove(item);
                _context.Inventory.Include(x => x.Items);
                await _context.SaveChangesAsync();
                return Ok($"Item with ID {id} has been deleted"); 

            } catch (Exception e){
                return BadRequest(e.ToString());
            }
           
        }

    }
}
