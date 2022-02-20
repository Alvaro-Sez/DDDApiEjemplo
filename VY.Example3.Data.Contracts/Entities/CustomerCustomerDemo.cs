﻿using System;
using System.Collections.Generic;

#nullable disable

namespace VY.Example3.Data.Contracts.Entities
{
    public partial class CustomerCustomerDemo
    {
        public string CustomerId { get; set; }
        public string CustomerTypeId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual CustomerDemographic CustomerType { get; set; }
    }
}
