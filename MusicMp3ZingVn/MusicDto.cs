using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MusicMp3ZingVn
{
    public class MusicDto
    {
        [JsonProperty("song_id")]
        public int Id { get; set; }

        [JsonProperty("song_id_encode")]
        public string SongKey { get; set; }

        [JsonProperty("video_id_encode")]
        public string VideoKey { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("artist_id")]
        public string ArtistId { get; set; }

        [JsonProperty("artist")]
        public string Artist { get; set; }

        [JsonProperty("album_id")]
        public string AlbumId { get; set; }

        [JsonProperty("album")]
        public string Album { get; set; }

        [JsonProperty("composer_id")]
        public string ComposerId { get; set; }

        [JsonProperty("composer")]
        public string Composer { get; set; }

        [JsonProperty("lyrics_file")]
        public string LyricsFile { get; set; }

        [JsonProperty("total_play")]
        public int TotalPlay { get; set; }

        [JsonProperty("source")]
        public SourceDto Sources { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }
    }
}
