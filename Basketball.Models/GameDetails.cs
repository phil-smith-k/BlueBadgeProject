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
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public DateTime Date { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
    }
}
