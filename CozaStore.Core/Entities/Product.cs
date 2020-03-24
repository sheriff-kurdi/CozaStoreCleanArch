using CozaStore.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Type = CozaStore.Core.Enums.Type;

namespace CozaStore.Core.Entities
{
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public Category Category { get; set; }
        public Type Type { get; set; }
        public Size Size { get; set; }
    }
}
