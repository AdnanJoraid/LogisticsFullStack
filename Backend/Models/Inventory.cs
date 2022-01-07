using System;
using System.Collections.Generic;


namespace Backend.Models
{
    public class Inventory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        private List<Item> _items;
        public List<Item> Items
        {
            get { return _items; }
            set { _items = value; }
        }

    }
}