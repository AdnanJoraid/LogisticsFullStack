using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Backend.Persistence;


namespace Backend.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class WarehouseController : ControllerBase{
        private readonly DataContext _context; 

        public WarehouseController(DataContext context)
        {
            this._context = context; 
            
        }

        

    }
}