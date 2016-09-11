using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using AutoMapper;
using Core;
using Core.Entity;
using MusicMp3ZingVn;
using THttpWebRequest;

namespace NhacCuaTuiCom
{
    public class NhacCuaTuiClient : MusicDownloaderBase
    {
        private static readonly WebHttpClient WebRequest;
        static NhacCuaTuiClient()
        {
            WebRequest = new WebHttpClient();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<MusicDto, Music>()
                .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Title))
                .ForMember(des => des.Sources, opt => opt.ResolveUsing<SourceResolver>());
            });
        }
        protected string GetKey(string url)
        {
            return Regex.Match(url, @"\.(?<key>[a-zA-Z0-9]+)\.html").Groups["key"].Value;
        }

        protected string GetXmlLink(string url)
        {
            string type = null;
            var key = GetKey(url);
            WebRequest.Get(string.Format("{0}{1}", "https://www.nhaccuatui.com/m/", key));
            if (url.Contains("/video/"))
                type = "key3";
            if (url.Contains("/playlist/"))
                type = "key2";
            if (url.Contains("/bai-hat/"))
                type = "key1";
            return string.Format("https://www.nhaccuatui.com/flash/xml?{0}={1}", type, Regex.Match(WebRequest.LocationClient, @"file=nullflash/xml\?key\d=(?<key>\w+)").Groups["key"].Value);
        }

        private IEnumerable<Music> GetAllMusic(string url)
        {
            var key = GetXmlLink(url);
            var value = Regex.Match(key, @"xml\?(?<key>key\d)").Groups["key"].Value;
            var content = WebRequest.Get(key);
            var document = new XmlDocument();
            document.LoadXml("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>" + content);
            if (document.DocumentElement == null)
            {
                yield return null;
            }
            var selectNodes = document.DocumentElement.SelectNodes("//track");
            if (selectNodes == null)
                yield return null;
            foreach (XmlNode nodeItem in selectNodes)
            {
                if (nodeItem == null)
                    continue;

                string link = null, title = null, artist = null, type = null;
                var selectSourceNode = nodeItem.SelectSingleNode(".//location");
                if (value.Equals("key3"))
                    selectSourceNode = nodeItem.SelectSingleNode(".//bklink");
                if (selectSourceNode != null)
                {
                    link = selectSourceNode.InnerText;
                }
                var selectTitleNode = nodeItem.SelectSingleNode(".//title");
                if (selectTitleNode != null)
                {
                    title = selectTitleNode.InnerText;
                }
                var selectArtistNode = nodeItem.SelectSingleNode(".//creator");
                if (selectArtistNode != null)
                {
                    artist = selectArtistNode.InnerText;
                }
                if (string.IsNullOrEmpty(link))
                    continue;
                type = Regex.Match(link, @"\.(?<key>\w+$)").Groups["key"].Value;
                yield return new Music();
                var resuft = new
                {
                    Link = link,
                    Title = title,
                    Artist = artist,
                    Type = type
                };
            }
        } 

        public override Music GetMusicInfo(string url)
        {
            var allMusic = GetAllMusic(url).ToList();
            if (allMusic.Any())
                return allMusic[0];
            return null;
        }

        public override IEnumerable<Music> GetPlaylistInfo(string url)
        {
            return GetAllMusic(url);
        }
    }
}
