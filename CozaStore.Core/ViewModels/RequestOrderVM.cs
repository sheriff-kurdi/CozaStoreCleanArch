using CozaStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CozaStore.Core.ViewModels
{
    public class RequestOrderVM
    {

        public int id { get; set; }
        [Required]
        public int ItemNumbers { get; set; }
        [Required]
        public Product product { get; set; }
        [Required]
        public int Phone { get; set; }
        [Required]
        public string CustomerName { get; set; }
    }
}
