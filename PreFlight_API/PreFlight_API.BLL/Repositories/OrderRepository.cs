﻿using Microsoft.EntityFrameworkCore;
using PreFlight.AI.Shared.Things;
using PreFlight.Infrastructure.Repositories;
using PreFlight_API.BLL.Contexts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PreFlight.Infrastructure.Repositories
{
    public class OrderRepository : GenericRepository<Order>
    {
        public OrderRepository(GeneralDbContext context) : base(context)
        {
        }

        public override IEnumerable<Order> Find(Expression<Func<Order, bool>> predicate)
        {
            return context.Orders
                .Include(order => order.LineItems)
                .ThenInclude(lineItem => lineItem.Product)
                .Where(predicate).ToList();
        }

        public override Order Update(Order entity)
        {
            var order = context.Orders
                .Include(o => o.LineItems)
                .ThenInclude(lineItem => lineItem.Product)
                .Single(o => o.OrderId == entity.OrderId);

            order.OrderDate = entity.OrderDate;
            order.LineItems = entity.LineItems;

            return base.Update(order);
        }
    }
}
