﻿using System;
using System.Collections.Generic;

#nullable disable

namespace VY.Example3.Data.Contracts.Entities
{
    public partial class QuarterlyOrder
    {
        public string CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
