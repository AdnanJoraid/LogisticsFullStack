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

    POST Items(JSON) - adds multiple items 
    POST Item(Item item) - adds one item 
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

        
    }
}
