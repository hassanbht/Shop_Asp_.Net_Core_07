﻿namespace Asp06Store.ShopUI.Models
{
    public class Order
    {
        public int Id {  get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public List<OrderDetail> orderDetails { get; set; } = new List<OrderDetail>();

    }
}
