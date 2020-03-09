using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.Data
{
    public class Player
    {
		[Key]
		public int PlayerId { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }
		public string FullName { get => FirstName + " " + LastName; }

		[ForeignKey(nameof(Team))]
		public int TeamId { get; set; }
		public virtual Team Team { get; set; }
		public int GamesPlayed
		{
			get
			{
				int gamesPlayed = 0;
				foreach(PlayerStats playerStats in PlayerStats)
				{
					gamesPlayed += 1;
				}
				return gamesPlayed;
			}
		}
		public decimal AveragePoints
		{
			get
			{
				int totalPoints = 0;
				foreach(PlayerStats playerStats in PlayerStats)
				{
					totalPoints += playerStats.Points;
				}
				int averagePoints = totalPoints / GamesPlayed;
				return Convert.ToDecimal(averagePoints);
			}
		}
		public decimal AverageRebounds
		{
			get
			{
				int totalRebounds = 0;
				foreach (PlayerStats playerStats in PlayerStats)
				{
					totalRebounds += playerStats.Rebounds;
				}
				int averageRebounds = totalRebounds / GamesPlayed;
				return Convert.ToDecimal(averageRebounds);
			}
		}
		public decimal AverageAssists
		{
			get
			{
				int totalAssists = 0;
				foreach (PlayerStats playerStats in PlayerStats)
				{
					totalAssists += playerStats.Assists;
				}
				int averageAssists = totalAssists / GamesPlayed;
				return Convert.ToDecimal(averageAssists);
			}
		}
		public ICollection<PlayerStats> PlayerStats { get; set; }

	}
}
