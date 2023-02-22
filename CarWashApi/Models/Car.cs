using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required]
        public string CarModel { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
