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
    POST Inventory - Creates an Inventory
    POST Items(JSON) - adds multiple items 
    POST Item(Item item) - adds one item 
    POST Item To inventory - Add Item to a specified Inventory
    GET Item by ID 
    GET all items 
    Edit Item by Id
    GET List of items 
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
                var inventory = await _context.Inventory.Include(x => x.Items).FirstOrDefaultAsync(x => x.Name.Equals("LogisticsDefaultInventory"));
                inventory.Items.Add(item);
                await _context.SaveChangesAsync();

                return Ok($"The item {item.ItemName} was added to the database.");

            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetItems()
        {

            return Ok(_context.Inventory.Include(x => x.Items).ToList());
        }


    }
}
