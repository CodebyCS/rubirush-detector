using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MonitorBot.Models
{
    public class GuildMember
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("rank")]
        public string Rank { get; set; }

        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("vocation")]
        public string Vocation { get; set; }


    }
}
