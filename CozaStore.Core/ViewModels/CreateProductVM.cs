using CozaStore.Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CozaStore.Core.ViewModels
{
    public class CreateProductVM : Product
    {
        //public int Id { get; set; }
        //[Required]
        //public string Name { get; set; }
        //[Required]
        //public int Price { get; set; }
        [Required]
        public IFormFile PhotoBinary { get; set; }
    }
}
