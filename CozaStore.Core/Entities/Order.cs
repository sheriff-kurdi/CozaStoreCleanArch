using CozaStore.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CozaStore.Core.Entities
{
    public class Order
    {

        public int Id { get; set; }
        public string ItemName { get; set; }
        public int ItemNumbers { get; set; }
        public Size Size { get; set; }
        public int TotallCost { get; set; }
        public int Phone { get; set; }
        public string CustomerName { get; set; }
        public string Image { get; set; }
    }
}
