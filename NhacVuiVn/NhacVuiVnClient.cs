using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using Core;
using Core.Entity;
using Newtonsoft.Json;
using NhacVuiVn.Entity;

namespace NhacVuiVn
{
    public class NhacVuiVnClient : MusicDownloaderBase
    {
        private static readonly WebHttpClient WebRequest;
        static NhacVuiVnClient()
        {
            WebRequest = new WebHttpClient();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<MusicDto, Music>()
                .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(des => des.Sources, opt => opt.ResolveUsing<SourceResolver>());
            });
        }

        protected string GetXmlLink(string url)
        {
            var content = WebRequest.Get(url);
            return Regex.Match(content, @"var v_arr_playlist_zplayer = eval\((?<key>.+)\)").Groups["key"].Value;
        }

        public override Music GetMusicInfo(string url)
        {
            return GetPlaylistInfo(url).ElementAt(0);
        }

        public override IEnumerable<Music> GetPlaylistInfo(string url)
        {
            var xmlLink = GetXmlLink(url);
            var listMusic = JsonConvert.DeserializeObject<List<MusicDto>>(xmlLink);
            var musics = Mapper.Map<List<MusicDto>, List<Music>>(listMusic);
            return musics;
        }
    }
}
