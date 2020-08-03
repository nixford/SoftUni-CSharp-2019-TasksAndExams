﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.ViewModels.Product.OutputViewModels
{
    public class ListAllProductsViewModel
    {
        public string ProductId { get; set; }
        public string Name { get; set; }

        public string ProductType { get; set; }

        public decimal Price { get; set; }
    }
}
