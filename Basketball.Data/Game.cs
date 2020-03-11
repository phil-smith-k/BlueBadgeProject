using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.Data
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }

        [ForeignKey(nameof(HomeTeam))]
        public int? HomeTeamId { get; set; }
        public virtual Team HomeTeam { get; set; }

        [ForeignKey(nameof(AwayTeam))]
        public int? AwayTeamId { get; set; }
        public virtual Team AwayTeam { get; set; }

        [Required]
        public DateTime Date { get; set; }


        public int HomeTeamScore
        {
            get
            {
                int homePoints = 0;
                foreach (PlayerStats playerStats in PlayerStats)
                {
                    if (playerStats.Player.Team.Name == HomeTeam.Name)
                    {
                        homePoints += playerStats.Points;
                    }
                }
                return homePoints;
            }
        }


        public int AwayTeamScore
        {
            get
            {
                int awayPoints = 0;
                foreach (PlayerStats playerStats in PlayerStats)
                {
                    if (playerStats.Player.Team.Name == AwayTeam.Name)
                    {
                        awayPoints += playerStats.Points;
                    }
                }
                return awayPoints;
            }
        }

        public string Location { get => HomeTeam.Location; }

        public string Winner
        {
            get
            {
                if (HomeTeamScore == 0 && AwayTeamScore == 0)
                {
                    return "TBD";
                }
                else
                { 
                    if (HomeTeamScore > AwayTeamScore)
                    {
                        return HomeTeam.Name;
                    }
                    else
                    {
                        return AwayTeam.Name;
                    }
                }
            }
        }
        public string Loser
        {
            get
            {
                if (Winner == "TBD")
                {
                    return "TBD";
                }
                else
                {

                    if (Winner == HomeTeam.Name)
                    {
                        return AwayTeam.Name;
                    }
                    else
                    {
                        return HomeTeam.Name;
                    }
                }
            }
        }
        public virtual ICollection<PlayerStats> PlayerStats { get; set; }


    }
}
