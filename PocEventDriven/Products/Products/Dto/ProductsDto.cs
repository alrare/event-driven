﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.SharedDto
{
    public class ProductDto
    {
        public record FullProductResponse(int Id, string Name, string Description);

        public record ProductUpdated(int Id, string Name);
    }
}
