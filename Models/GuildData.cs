using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonitorBot.Models
{
    public class GuildData
    {
        [JsonProperty("members")]
        public List<GuildMember> Members { get; set; }


    }
}
