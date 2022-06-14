using PreFlight_API.BLL.Models;
using System;

namespace PreFlight_API.API.Middlewares.DataContracts
{
    public class RegisterLineItemRequest : LineItemDto
    {
        // what information will we provide/require whenever one of these requests comes in.
    }

    public class LineItemDto 
    {
        public int Quantity { get; set; }

        public Product Product { get; set; }
        public Guid ProductId { get; set; }

        public Order Order { get; set; }
    }

  

    public class RegisterLineItemResponse
    {
        public long Id { get; set; }
    }

    public class EditLineItemRequest
    {
        public int Quantity { get; set; }

        public Product Product { get; set; }
    }

    public class OrderRequest
    {
        public OrderEnrollmentDto[] Enrollments { get; set; }
    }

    public class OrderEnrollmentDto
    {
        public Order order { get; set; }
    }

    public class GetOrderResponse
    {
        public Product[] Products { get; set; }
        public OrderEnrollmentDto[] Enrollments { get; set; }
    }
}

