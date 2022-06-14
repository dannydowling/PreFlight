using System;
using System.Collections.Generic;
using System.Text;

namespace PreFlight_API.BLL.Models
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
