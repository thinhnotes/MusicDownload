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
using NhacSoNet.Entity;

namespace NhacSoNet
{
    public class NhacSoClient:MusicDownloaderBase
    {
        private static readonly WebHttpClient WebRequest;
        static NhacSoClient()
        {
            WebRequest = new WebHttpClient();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<MusicDto, Music>()
                .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(des => des.Sources, opt => opt.ResolveUsing<SourceResolver>());
            });
        }
        private string baseUrl = "http://nhacso.net/playlists/ajax-get-detail-playlist?dataId=";
        private string GetKey(string url)
        {
            return Regex.Match(url, @"\.(?<key>\w+)\.html").Groups["key"].Value;
        }

        private string GetXmlLink(string url)
        {
            return string.Format("{0}{1}", baseUrl, Regex.Match(url, @"\.(?<key>[a-zA-Z0-9=]+)\.html").Groups["key"].Value);
        }

        public override Music GetMusicInfo(string url)
        {
            return GetPlaylistInfo(url).ElementAt(0);
        }

        public override IEnumerable<Music> GetPlaylistInfo(string url)
        {
            var xmlLink = GetXmlLink(url);
            var content = WebRequest.Get(xmlLink);
            var playList = JsonConvert.DeserializeObject<PlayList>(content);
            var musics = Mapper.Map<List<MusicDto>, List<Music>>(playList.MusicDtos.ToList());
            return musics;
        }
    }
}
