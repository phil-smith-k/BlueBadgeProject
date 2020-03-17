using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.Data
{
    public class PlayerStats
    {
        [Key]
        public int PlayerStatsId { get; set; }

        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        public virtual Game Game { get; set; }


        [ForeignKey(nameof(Player))]
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }

        public int Points { get; set; }
        public int Rebounds { get; set; }
        public int Assists { get; set; }

    }
}
