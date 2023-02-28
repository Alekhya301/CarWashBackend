using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public string  WashingInstructions { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string PackageName { get; set; }
        public decimal Price { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }

    }
}
