using Basketball.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.Models
{
    public class TeamDetails
    {
        public string Location { get; set; }
        public string Name { get; set; }
        public int ConferenceId { get; set; }
        public List<PlayerList> Players { get; set; }
        public List<GameList> HomeGames { get; set; }
        public List<GameList> AwayGames { get; set; }
    }
}
