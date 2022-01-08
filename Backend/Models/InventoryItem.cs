using System;
using System.Collections.Generic;


namespace Backend.Models
{
    public class InventoryItem
    {
        public Guid Id { get; set; }
        public string ItemName { get; set; }

        public string Description { get; set; }

        public int BeginningQuantity { get; set; }

        public bool IsAvailable { get; set; }

        public double ItemPrice { get; set; }

        public DateTime DateOfCreation { get; set; }


    }
}