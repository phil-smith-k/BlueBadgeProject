using Basketball.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.Models
{
    public class GameDetails
    {
        public int GameId { get; set; }
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
        public string WinningTeamName { get; set; }
        public string LosingTeamName { get; set; }
        public List<PlayerStats> PlayerStats { get; set; }
    }
}
