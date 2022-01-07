using System;
using System.Collections.Generic;


namespace Backend.Models
{
    public class Inventory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Item> Items { get; set; }

    }
}