using Basketball.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.Models
{
    public class PlayerDetails
    {
        public int PlayerId { get; set; }
		public string FullName { get; set; }
		public string TeamName { get; set; }
        public int GamesPlayed { get; set; }
        public decimal AveragePoints { get; set; }
        public decimal AverageRebounds { get; set; }
        public decimal AverageAssists { get; set; }
    }
}
