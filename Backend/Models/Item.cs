using System;
using System.Collections.Generic;


namespace Backend.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public string ItemName { get; set; }

        public string Description { get; set; }

        public int QuantityStock { get; set; }

        private bool _isAvailable;
        public bool IsAvailable
        {
            get { return _isAvailable; }
            set
            {
                _isAvailable = QuantityStock > 0 ? true : false;
            }
        }

        public double ItemPrice { get; set; }

        public DateTime DateOfCreation { get; set; }
    }
}