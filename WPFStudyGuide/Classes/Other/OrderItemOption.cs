﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFStudyGuide.Classes.Other
{
    public class OrderItemOption
    {
        public long Id { get; set; }
        public Guid? StoreId { get; set; }
        public long OrderItemId { get; set; }
        public int ProductOptionId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public OrderItem OrderItem { get; set; }
        public ProductOption ProductOption { get; set; }
    }
}
