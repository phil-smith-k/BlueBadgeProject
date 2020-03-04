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
		public int HomeTeamId { get; set; }
		public virtual Team HomeTeam { get; set; }

		[ForeignKey(nameof(AwayTeam))]
		public int AwayTeamId { get; set; }
		public virtual Team AwayTeam { get; set; }

		[Required]
		public DateTime Date { get; set; }

		[Required]
		public int HomeTeamScore { get; set; }

		[Required]
		public int AwayTeamScore { get; set; }

		public string Location { get; }

		public string Winner
		{
			get
			{
				if(HomeTeamScore > AwayTeamScore)
				{
					return HomeTeam.Name;
				}
				else
				{
					return AwayTeam.Name;
				}
			}
		}
		public string Loser
		{
			get
			{
				if(Winner == HomeTeam.Name)
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
}
