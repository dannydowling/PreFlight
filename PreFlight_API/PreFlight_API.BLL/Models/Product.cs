using PreFlight_API.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PreFlight.AI.Shared.Things
{
    public class Product : Entity
    {
        public Guid ProductId { get; private set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public Product()
        {
            ProductId = Guid.NewGuid();
        }
    }
}
