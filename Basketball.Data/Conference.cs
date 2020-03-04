using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.Data
{
	public class Conference
	{
		[Key]
		public int ConferenceId { get; set; }

		[Required]
		public string Name { get; set; }
	}

}
