using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Backend.Models;
using Backend.Persistence;
/*
The controller InventoryController contains all the API endpoints that are associated with the adding, deleting, updating, and retrieving of Inventory Items. 
The API Controller contains a total of six endpoints. Which are: 
1) POST - http://localhost:5000/api/inventory : Adds an inventory item to the SQLite database.
2) POST - http://localhost:5000/api/inventory/items/add : Adds a list of inventory items objects to the database. 
3) GET  - http://localhost:5000/api/inventory/{id} : Retrieves an inventory item with a given ID. 
4) GET  - http://localhost:5000/api/inventory/items/ : Retrieves all the inventory items in the database. 
5) PUT  - http://localhost:5000/api/inventory/update/item/{id} : Updates an inventroy item's data with an updated inventory item passed alongside the ID of the old inventroy item.
6) DELETE - http://localhost:5000/api/inventory/{id} : Deletes an inventory item with a given ID. 
*/
namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly DataContext _context;

        public InventoryController(DataContext context)
        {
            this._context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody] InventoryItem item)
        {
            /*
            Summary: AddItem method is responsible for creating inventory items and adding them to the SQLite database. 
            Arguments: InventoryItem object from the request body : (JSON BODY) 
            Return: Two Cases:
                1-Http Response. A 200 Status code is returned with the item name if the item does not exist.
                2-Http Response. A 400 status code is returned (error) if the item already exists in the database. 
            */
            try
            {
                //Check if item already exists
                InventoryItem itemInDb = await _context.Items.FirstOrDefaultAsync(x => x.ItemName.Equals(item.ItemName));

                if (itemInDb != null)
                {
                    return BadRequest($"The item {item.ItemName} already exists in the database. Did you mean to update?\nIf yes please use the update endpoint or Transaction endpoint.");
                }

                item.DateOfCreation = DateTime.Now;
                item.IsAvailable = item.BeginningQuantity > 0 ? true : false;
                _context.Items.Add(item);
                await _context.SaveChangesAsync();

                return Ok($"The item {item.ItemName} has been added to the database.");

            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpPost("items/add")]
        public async Task<IActionResult> AddItemsListToInventory([FromBody] List<InventoryItem> items)
        {
            /*
            Summary: AddItemsListToInventory method is responsible for adding a list of items from the request body to the SQLite database. If one of the item already exists. That
            item would not be added. However, all other items will be. 
            Arguments: A list of InventoryItem object from the request body : (JSON BODY) 
            Return: Two Cases:
                1-Http Response. A 200 Status code is returned with a confirmation.
                2-Http Response. A 400 status code is returned (error) if the item list is empty. 
            */
            try
            {

                if (items.Count < 1)
                {
                    return BadRequest($"Items list is empty");
                }

                int totalExistedItems = 0;


                foreach (InventoryItem item in items)
                {
                    InventoryItem itemInDatabase = await _context.Items.FirstOrDefaultAsync(x => x.ItemName.Equals(item.ItemName));

                    if (itemInDatabase != null)
                    {
                        items.Remove(item); //remove item for items list since it already exists.
                        totalExistedItems++;
                        continue; //if item already exists, skip it and go to next item. 
                    }
                    item.DateOfCreation = DateTime.Now;
                    item.IsAvailable = item.BeginningQuantity > 0 ? true : false;
                }

                await _context.Items.AddRangeAsync(items);
                await _context.SaveChangesAsync();
                return Ok($"List of items has been added to the database. The total of items wre not added to database: {totalExistedItems}");


            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemById(string id)
        {
            /*
            Summary: GetItemById method is responsible for retrieving an item by ID. 
            Arguments: A string that represents the item ID from the request body : (JSON BODY) 
            Return: Two Cases:
                1-Http Response. A 200 Status code is returned with the item.
                2-Http Response. A 404 status code is returned (error) if the item with the given ID does not exists in the database. 
            */
            try
            {
                InventoryItem item = await _context.Items.FirstOrDefaultAsync(x => x.Id.Equals(new Guid(id)));

                if (item == null)
                {
                    return NotFound($"Item with the id {id} does not exist.");
                }

                return Ok(item);
            }
            catch (Exception e)
            {
                return BadRequest($"Item with the id {id} does not exist. For a detailed error, read below.\n\n\n{e.ToString()}");
            }
        }





        [HttpGet("items/")]
        public async Task<IActionResult> GetAllDatabaseItems()
        {
            /*
            Summary: GetAllDatabaseItems method is responsible for retrieving all the items in the database. 
            Arguments: None
            Return: Two Cases:
              1-Http Response. A 200 Status code is returned with a list of items list.
              2-Http Response. A 400 status code is returned (error) if any error occurred.
            */
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
        public async Task<IActionResult> UpdateItemById(string id, [FromBody] InventoryItem updatedItem)
        {
            /*
            Summary: UpdateItemById method is responsible for updating an old item with a new updated item. 
            Arguments: A string that represents the item ID from the request body and an InventoryItem object that holds the updated data. : (JSON BODY) 
            Return: Three Cases:
               1-Http Response. A 200 Status code is returned with the updated item ID.
               2-Http Response. A 404 status code is returned (error) if the item with the given ID does not exists in the database. 
               3-Http Response. A 400 status code is returned (error) if string ID from the request is empty. 
            */
            try
            {

                if (string.IsNullOrEmpty(id))
                    return BadRequest("Given id is empty.");

                InventoryItem oldItem = await _context.Items.FirstOrDefaultAsync(x => x.Id.Equals(new Guid(id)));
                if (oldItem == null)
                    return NotFound("Item with the given Id does not exist");

                oldItem.ItemName = updatedItem.ItemName;
                oldItem.ItemPrice = updatedItem.ItemPrice;
                oldItem.BeginningQuantity = updatedItem.BeginningQuantity;
                oldItem.Description = updatedItem.Description;
                oldItem.IsAvailable = updatedItem.BeginningQuantity > 0 ? true : false;
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
        public async Task<IActionResult> DeleteItemWithId(string id)
        {
            /*
            Summary: DeleteItemWithId method is responsible for deleting an inventory item from the database. 
            Arguments: A string that represents the item ID of the inventory item from the request body : (JSON BODY) 
            Return: Three Cases:
               1-Http Response. A 200 Status code is returned with the deleted item ID.
               2-Http Response. A 404 status code is returned (error) if the item with the given ID does not exists in the database. 
               3-Http Response. A 400 status code is returned (error) if string ID from the request is empty. 
            */

            try
            {

                if (string.IsNullOrEmpty(id))
                    return BadRequest("the given ID is empty");

                InventoryItem item = await _context.Items.FirstOrDefaultAsync(x => x.Id.Equals(new Guid(id)));

                if (item == null)
                    return NotFound($"The item with the given ID: {id} does not exist");

                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
                return Ok($"Item with ID {id} has been deleted");

            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }

        }

    }
}
