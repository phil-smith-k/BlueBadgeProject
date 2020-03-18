using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.Data
{
    public class Token
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public int ExpiresIn { get; set; }
        public string UserName { get; set; }
        [JsonProperty(".issued")]
        public string Issued { get; set; }
        [JsonProperty(".expires")]
        public string Expires { get; set; }
    }
}
