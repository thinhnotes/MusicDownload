using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NhacVuiVn.Entity
{
    public class MusicDto
    {
        public int Id { get; set; }
        public string Mediaid { get; set; }
        [JsonProperty("title")]
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonProperty("File")]
        public string Link { get; set; }
        public string Bitrate { get; set; }
    }
}
