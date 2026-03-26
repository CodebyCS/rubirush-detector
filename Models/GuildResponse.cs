using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonitorBot.Models
{
    public class GuildResponse
    {
        [JsonProperty("guild")]
        public GuildData Guild { get; set; }
    }
}
