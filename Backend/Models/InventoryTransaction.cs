using System;
using System.Collections.Generic;


namespace Backend.Models{
    public enum Type {
        IN, OUT 
    }
    public class InventoryTransaction{
        public Guid Id { get; set; }

        public InventoryItem InventoryItem { get; set; }

        public Warehouse Warehouse { get; set; }

        public string TypeString { get; set; }

        public Type Type { get; set; }

        public Location ItemLocation { get; set; }

        public string FormattedLocation { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}