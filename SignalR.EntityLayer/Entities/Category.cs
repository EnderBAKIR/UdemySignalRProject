﻿namespace SignalR.EntityLayer.Entities
{
    public class Category
    {
        
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public bool CategoryStatus { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
    }
}
