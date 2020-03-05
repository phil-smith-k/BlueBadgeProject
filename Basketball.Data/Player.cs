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

	}
}
