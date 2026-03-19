using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonitorBot.Models
{
    public class Player
    {
        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("value")]
        public object ValueRaw { get; set; } // Lê qualquer coisa (texto ou número)

        [JsonIgnore]
        public long Value
        {
            get
            {
                if (ValueRaw == null) return 0;
                return long.TryParse(ValueRaw.ToString(), out long res) ? res : 0;
            }
        }

    }
}
