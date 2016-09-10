using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using Core;
using Core.Entity;
using Newtonsoft.Json;
using THttpWebRequest;

namespace MusicMp3ZingVn
{
    public class Mp3ZingVnClient : MusicDownloaderBase
    {
        static Mp3ZingVnClient()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Music, MusicDto>().ForMember(des => des.Sources, opt => opt.MapFrom(src => src.Sources.ElementAt(0)));
                cfg.CreateMap<MusicDto, Music>()
                .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Title))
                .ForMember(des => des.Sources, opt => opt.ResolveUsing<SourceResolver>());
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
            var musicDto = JsonConvert.DeserializeObject<MusicDto>(content);
            return Mapper.Map<MusicDto, Music>(musicDto);
        }

        public override IEnumerable<Music> GetPlaylistInfo(string url)
        {
            throw new NotImplementedException();
        }
    }
}
