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

    }
}
