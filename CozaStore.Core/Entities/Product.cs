using CozaStore.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Type = CozaStore.Core.Enums.Type;

namespace CozaStore.Core.Entities
{
    public class Product
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        public string Image { get; set; }
        [Required]
        public Category Category { get; set; }
        [Required]
        public Type Type { get; set; }
        [Required]
        public Size Size { get; set; }
    }
}
