using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entity;
using Newtonsoft.Json;

namespace NhacSoNet.Entity
{
    public class PlayList
    {
        [JsonProperty("object_id")]
        public string Id { get; set; }

        [JsonProperty("object_name")]
        public string Name { get; set; }

        [JsonProperty("object_type")]
        public string Type { get; set; }
        [JsonProperty("songs")]
        public IEnumerable<MusicDto> MusicDtos { get; set; }
    }
}
