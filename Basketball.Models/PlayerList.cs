using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.Models
{
    public class PlayerList
    {
        public int PlayerId { get; set; }
        public string FullName { get; set; }
        public string TeamName { get; set; }
        public decimal AveragePoints { get; set; }
    }
}
