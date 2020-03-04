using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

    }
}
