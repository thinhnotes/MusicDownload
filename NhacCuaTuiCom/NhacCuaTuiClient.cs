using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using Core;
using Core.Entity;

namespace NhacCuaTuiCom
{
    class NhacCuaTuiClient : MusicDownloaderBase
    {
        static NhacCuaTuiClient()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Music, MusicDto>();
            });
        }
        public string Url { get; } = "http://api.mp3.zing.vn/api/mobile/song/getsonginfo?requestdata={{\"id\":\"{0}\"}}";

        string GetKey(string url)
        {
            string pattern = "(?<key>[A-Z0-9]+)\\.html";
            var match = Regex.Match(url, pattern);
            return match.Groups["key"]?.Value ?? string.Empty;
        }

        public override Music GetMusicInfo(string url)
        {
            var key = GetKey(url);
            string rawUrl = String.Format(Url, key);
            var content = Get(rawUrl);
            throw new NotImplementedException();
        }

        public override IEnumerable<Music> GetPlaylistInfo(string url)
        {
            throw new NotImplementedException();
        }
    }
}
