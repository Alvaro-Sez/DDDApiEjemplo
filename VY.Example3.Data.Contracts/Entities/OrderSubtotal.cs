using System;
using System.Collections.Generic;

#nullable disable

namespace VY.Example3.Data.Contracts.Entities
{
    public partial class OrderSubtotal
    {
        public int OrderId { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
