using Basketball.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.Models
{
    public class PlayerStatsList
    {
        public int PlayerStatsId { get; set; }

        public PlayerDetails Player { get; set; }
        public int GameId { get; set; }
        public string Date { get; set; }
        public string FullName { get; set; }
        public int Points { get; set; }
        public int Rebounds { get; set; }
        public int Assists { get; set; }
    }
}
