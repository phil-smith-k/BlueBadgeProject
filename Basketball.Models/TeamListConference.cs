using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.Models
{
    public class TeamListConference
    {
        public int TeamId { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
        public string Record { get; set; }
        public bool Favorite { get; set; }
    }
}
