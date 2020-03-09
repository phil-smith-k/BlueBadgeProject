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
        public DateTime Date { get; set; }
        public int GameId { get; set; }
        public string FullName { get; set; }
    }
}
