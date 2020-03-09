using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.Models
{
    public class GameEdit
    {
        [Required]
        public int GameId { get; set; }

        [Required]
        public int HomeTeamId { get; set; }

        [Required]
        public int AwayTeamId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        // [Required]
        // public int HomeTeamScore { get; set; }

        // [Required]
        // public int AwayTeamScore { get; set; }
    }
}
