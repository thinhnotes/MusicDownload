using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NhacSoNet.Entity
{
    public class MusicDto
    {
        [JsonProperty("song_id")]
        public int Id { get; set; }

        [JsonProperty("Id")]
        public string SongId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("link_mp3")]
        public string Link { get; set; }
    }
}
