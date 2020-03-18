using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Basketball.Data
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey(nameof(Conference))]
        public int ConferenceId { get; set; }
        public virtual Conference Conference { get; set; }

        public virtual ICollection<Player> Roster { get; set; }
        public virtual ICollection<PlayerStats> PlayerStats { get; set; }
        public virtual ICollection<ApplicationUser> UsersWhoFavorited { get; set; }

        [InverseProperty("HomeTeam")]
        public virtual ICollection<Game> HomeGameLog { get; set; }

        [InverseProperty("AwayTeam")]
        public virtual ICollection<Game> AwayGameLog { get; set; }
        public string Record
        {
            get
            {
                return Wins + "-" + Losses;
            }
        }
        public int Wins
        {
            get
            {
                int winCount = 0;
                foreach (Game game in AllGames)
                {
                    if (game.Winner == Name)
                    {
                        winCount += 1;
                    }
                }
                return winCount;
            }
        }
        public int Losses
        {
            get
            {
                int lossCount = 0;
                foreach (Game game in AllGames)
                {
                    if (game.Loser == Name)
                    {
                        lossCount += 1;
                    }
                }
                return lossCount;
            }
        }

        public virtual ICollection<Game> AllGames
        {
            get
            {
                if (AwayGameLog == null || HomeGameLog == null)
                {
                    return new List<Game>();
                }
                else
                {
                    return HomeGameLog.Concat<Game>(AwayGameLog).ToList();

                }
            }
        }


    }
}
