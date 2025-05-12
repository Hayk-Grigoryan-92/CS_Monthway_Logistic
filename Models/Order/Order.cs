using Azure.Core;
using lesson45.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson45.Models.Order
{
   
    public class Order
    {
        public int Id { get; set; }
        public Request OrderRequest { get; set; }

        public OrderStatus Status { get; set; }

        public Order(Request orderRequest, OrderStatus status)
        {
            OrderRequest = orderRequest;
            Status = status;
        }
        public Order(int id ,Request orderRequest, OrderStatus status)
        {
            Id = id;
            OrderRequest = orderRequest;
            Status = status;
        }
    }
}
