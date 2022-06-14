using System;
using System.Collections.Generic;
using System.Text;

namespace PreFlight_API.BLL.Models
{
    public class LineItem
    {
        public Guid LineItemId { get; set; }

        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
        public Guid ProductId { get; set; }

        public virtual Order Order { get; set; }
        public Guid OrderId { get; set; }

        public LineItem()
        {
            LineItemId = Guid.NewGuid();
        }
    }
}
