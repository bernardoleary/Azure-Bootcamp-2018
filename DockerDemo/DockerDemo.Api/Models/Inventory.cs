using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DockerDemo.Api.Models
{
    public class Inventory
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public int quantity { get; set; }
    }
}
