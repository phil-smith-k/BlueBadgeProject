using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.Models
{
    public class CreateNewPlayerStats
    {
        [Required]
        public int GameId { get; set; }
        [Required]
        public string Player { get; set; }
        [Required]
        public int Points { get; set; }
        [Required]
        public int Rebounds { get; set; }
        [Required]
        public int Assists { get; set; }
    }
}
