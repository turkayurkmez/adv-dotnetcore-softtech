﻿namespace eshop.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // TODO 1. Navigation Property'leri unutma!
        public ICollection<Product> Products { get; set; }
        /*
         * Category kozmetik = new();
         * kozmetik.Products.Add();
         */
    }
}
