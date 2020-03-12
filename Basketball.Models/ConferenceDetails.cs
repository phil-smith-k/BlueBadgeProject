using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.Models
{
    public class ConferenceDetails
    {
        public int ConferenceId { get; set; }
        public string ConferenceName { get; set; }
        public List<TeamListConference> Teams { get; set; }
    }
}
