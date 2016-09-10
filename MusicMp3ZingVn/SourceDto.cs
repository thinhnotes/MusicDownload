using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MusicMp3ZingVn
{
    public class SourceDto
    {
        [JsonProperty("128")]
        public string Link128 { get; set; }

        [JsonProperty("lossless")]
        public string Lossless { get; set; }

        [JsonProperty("320")]
        public string Link320 { get; set; }
    }
}
