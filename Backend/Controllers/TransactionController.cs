using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Backend.Persistence;
/*
The controller TransactionController contains all the API endpoints that are associated with the adding, deleting, updating, and retrieving of Transactions.
Transaction is what will connect the item, location and other related properties to the warehouse. The TransactionInventory is an object that will hold an inventory item with its 
corresponding warehouse location.  
The API Controller contains a total of # endpoints. Which are: 
1) POST - http://localhost:5000/api/transaction/{inventoryId}/{warehouseId} : Adds a transaction item to the SQLite database in addition to the warehouse and item associated with it.
2) GET  - http://localhost:5000/api/transaction/{id} : Retrieves a transaction with a given ID. 
3) GET  - http://localhost:5000/api/transaction/ : Retrieves all the transactions in the database. 
4) PUT  - http://localhost:5000/api/transaction/update/{id} : Updates a transaction data with an updated transaction passed alongside the ID of the old transaction.
5) DELETE - http://localhost:5000/api/transaction/delete/{id} : Deletes a transaction with a given ID. 
*/
namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly DataContext _context;

        public TransactionController(DataContext context)
        {
            this._context = context;

        }

        [HttpPost("{inventoryId}/{warehouseId}/{transactionType}")]
        public async Task<IActionResult> CreateInventoryTransaction(string inventoryId, string warehouseId, [FromBody] InventoryTransaction transaction, string transactionType)
        {
            try
            {
                if (string.IsNullOrEmpty(inventoryId) || string.IsNullOrEmpty(warehouseId))
                    return BadRequest("One or two of the IDs are emtpty.");

                InventoryItem item = await _context.Items.FirstOrDefaultAsync(x => x.Id.Equals(new Guid(inventoryId)));
                if (item == null)
                    return BadRequest($"Inventory item with ID {inventoryId} does not exist in the database");

                Warehouse warehouse = await _context.Warehouses.FirstOrDefaultAsync(x => x.Id.Equals(new Guid(warehouseId)));

                if (warehouse == null)
                    return BadRequest($"Warehouse with ID {warehouseId} does not exist in the database");


                InventoryTransaction transactionInDb = await _context.Transactions.FirstOrDefaultAsync(x => x.Id.Equals(transaction.Id));
                if (transactionInDb != null)
                {
                    return BadRequest("Transaction already exists in the database");
                }


                transaction.InventoryItem = item;
                transaction.Warehouse = warehouse;
                transaction.CreatedDate = DateTime.Now;

                switch (transactionType.ToUpper().Trim())
                {
                    case "IN":
                        transaction.Type = Models.Type.IN;
                        transaction.TypeString = transactionType.ToString();
                        break;
                    case "OUT":
                        transaction.Type = Models.Type.IN;
                        transaction.TypeString = transactionType.ToString();
                        break;
                }
                transaction.FormattedLocation = transaction.ItemLocation.FormatLocation();

                await _context.Transactions.AddAsync(transaction);
                await _context.SaveChangesAsync();

                return Ok($"Transaction with the ID {transaction.Id} has been issued on {transaction.CreatedDate}");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTransaction()
        {
            try
            {
                return Ok(await _context.Transactions.Include(x => x.InventoryItem).Include(x => x.Warehouse).Include(x => x.ItemLocation).ToListAsync());

            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionById(string id)
        {
            try
            {

                if (string.IsNullOrEmpty(id))
                    return BadRequest("Given id is empty");


                InventoryTransaction transaction = await _context.Transactions.Include(x => x.InventoryItem)
                .Include(x => x.Warehouse).Include(x => x.ItemLocation)
                .FirstOrDefaultAsync(x => x.Id.Equals(new Guid(id)));

                if (transaction == null)
                    return NotFound($"There is no record of a transaction with the ID {id}");


                return Ok(transaction);

            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateTransaction(string id, [FromBody] InventoryTransaction updatedTransaction)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return BadRequest("ID is empty");

                InventoryTransaction oldTransaction = await _context.Transactions.FirstOrDefaultAsync(x => x.Id.Equals(new Guid(id)));


                if (oldTransaction == null)
                    return NotFound($"There is no record of a transaction with the ID {id}");


                oldTransaction.InventoryItem = updatedTransaction.InventoryItem;
                oldTransaction.Warehouse = updatedTransaction.Warehouse;
                oldTransaction.Type = updatedTransaction.Type;
                oldTransaction.TypeString = updatedTransaction.Type.ToString();
                oldTransaction.CreatedDate = updatedTransaction.CreatedDate;
                oldTransaction.ItemLocation = updatedTransaction.ItemLocation;
                oldTransaction.FormattedLocation = updatedTransaction.ItemLocation.FormatLocation();
                oldTransaction.InventoryItem.IsAvailable = updatedTransaction.InventoryItem.BeginningQuantity > 0 ? true : false;

                await _context.SaveChangesAsync();
                return Ok($"The transaction with the ID {updatedTransaction.Id} has been updated");

            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteItemById(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return BadRequest("ID is empty");

                InventoryTransaction transaction = await _context.Transactions.FirstOrDefaultAsync(x => x.Id.Equals(new Guid(id)));

                if (transaction == null)
                    return NotFound($"There is no record for a transction with the ID {id}");

                _context.Remove(transaction);
                await _context.SaveChangesAsync();

                return Ok($"The transaction with the ID {id} has been deleted.");

            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }

        }
    }
}