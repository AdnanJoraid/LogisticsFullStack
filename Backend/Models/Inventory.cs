using System;
using System.Collections.Generic;


namespace Backend.Models
{
    public class Inventory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        private List<Item> _Items;
        public List<Item> Items
        {
            get { return _Items; }
            set { _Items = value; }
        }

    }
}