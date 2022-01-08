using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Backend.Persistence;
/*
The controller WarehouseController contains all the API endpoints that are associated with the adding, deleting, updating, and retrieving of Warehouses. 
The API Controller contains a total of five endpoints. Which are: 
1) POST - http://localhost:5000/api/warehouse : Adds a warehouse item to the SQLite database.
2) GET  - http://localhost:5000/api/warehouse/{id} : Retrieves a warehouse with a given ID. 
3) GET  - http://localhost:5000/api/warehouse/all/ : Retrieves all the warehouses in the database. 
4) PUT  - http://localhost:5000/api/warehouse/update/{id} : Updates a warehouse data with an updated warehouse passed alongside the ID of the old warehouse.
5) DELETE - http://localhost:5000/api/warehouse/{id} : Deletes a warehouse with a given ID. 
*/
namespace Backend.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class WarehouseController : ControllerBase{
        private readonly DataContext _context; 

        public WarehouseController(DataContext context)
        {
            this._context = context; 
            
        }

        [HttpPost]
        public async Task<IActionResult> AddWarehouse([FromBody] Warehouse warehouse)
        {
            /*
            Summary: AddWarehouse method is responsible for creating a warehouse and adding it to the SQLite database. 
            Arguments: Warehouse object from the request body : (JSON BODY) 
            Return: Three Cases:
                1-Http Response. A 200 Status code is returned with the warehouse ID.
                2-Http Response. A 400 status code is returned (error) if the item already exists in the database. 
                3-Http Response. A 400 status code is returned (error) if the iteam name or address is empty. 
            */
            try
            {

                Warehouse warehouseInDatabase = await _context.Warehouses.FirstOrDefaultAsync(x => x.Address.Equals(warehouse.Address) && x.Name.Equals(warehouse.Name));

                if (warehouseInDatabase != null)
                {
                    return BadRequest($"The warehouse with the name {warehouse.Name} and address {warehouse.Address} already exists in the database.");
                }

                if (warehouse.Address == null || warehouse.Name == null)
                {
                    return BadRequest("Warehouse name or address is empty.");
                }

                await _context.Warehouses.AddAsync(warehouse);
                await _context.SaveChangesAsync();

                return Ok($"Warehouse has been added to the database. The warehouse ID is {warehouse.Id}");

            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWarehouseById(string id)
        {
            /*
           Summary: GetWarehouseById method is responsible for retrieving a warehouse by ID from SQLite database
           Arguments: A string that represents the ID of the warehouse from the request body : (JSON BODY) 
           Return: Three Cases:
               1-Http Response. A 200 Status code is returned with the warehouse object.
               2-Http Response. A 404 status code is returned (error) if the warehouse with the given ID does not exists in the database. 
               3-Http Response. A 400 status code is returned (error) if the string ID given is empty. 
           */
            try
            {

                if (string.IsNullOrEmpty(id))
                    return BadRequest("Given ID is empty");

                Warehouse warehouse = await _context.Warehouses.FirstOrDefaultAsync(x => x.Id.Equals(new Guid(id)));

                if (warehouse == null)
                    return NotFound($"The warehouse with the ID {id} does not exist in the database.");

                return Ok(warehouse);

            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllWarehouses()
        {
            /*
           Summary: GetAllWarehouses method is responsible for retrieving all warehouses from SQLite database
           Arguments: None
           Return: All warehouses in the database (If found)
           */
            try
            {

                return Ok(await _context.Warehouses.ToListAsync());

            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateWarehouseById(string id, [FromBody] Warehouse updatedWarehouse)
        {
            /*
           Summary: UpdateWarehouseById method is responsible for updating a warehouse by ID from SQLite database
           Arguments: A string that represents the ID of the warehouse alongside the updated warehouse object from the request body : (JSON BODY) 
           Return: Three Cases:
               1-Http Response. A 200 Status code is returned with the updated warehouse ID.
               2-Http Response. A 404 status code is returned (error) if the warehouse with the given ID does not exists in the database. 
               3-Http Response. A 400 status code is returned (error) if the string ID given is empty. 
           */
            try
            {

                if (string.IsNullOrEmpty(id))
                    return BadRequest("ID given is empty");

                Warehouse oldWarehouse = await _context.Warehouses.FirstOrDefaultAsync(x => x.Id.Equals(new Guid(id)));

                if (oldWarehouse == null)
                    return NotFound($"The warehouse with the ID {id} does not exist in the database");

                oldWarehouse.Name = updatedWarehouse.Name;
                oldWarehouse.Address = updatedWarehouse.Address;

                await _context.SaveChangesAsync();

                return Ok($"The warehouse with the ID {id} has been updated");



            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWarehouseById(string id)
        {
            /*
           Summary: DeleteWarehouseById method is responsible for deleting a warehouse by ID from SQLite database
           Arguments: A string that represents the ID of the warehouse from the request body : (JSON BODY) 
           Return: Three Cases:
               1-Http Response. A 200 Status code is returned with the deleted warehouse ID.
               2-Http Response. A 404 status code is returned (error) if the warehouse with the given ID does not exists in the database. 
               3-Http Response. A 400 status code is returned (error) if the string ID given is empty. 
           */
            try
            {

                if (string.IsNullOrEmpty(id))
                    return BadRequest("The given ID is empty");

                Warehouse warehouse = await _context.Warehouses.FirstOrDefaultAsync(x => x.Id.Equals(new Guid(id)));

                if (warehouse == null)
                    return NotFound($"The warehouse with the ID {id} does not exist in the database.");

                _context.Warehouses.Remove(warehouse);
                await _context.SaveChangesAsync();

                return Ok($"The warehouse with the ID {id} has been deleted.");


            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }



    }
}