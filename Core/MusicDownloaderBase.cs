using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Core.Entity;
using Core.Enum;
using THttpWebRequest;

namespace Core
{
    public abstract class MusicDownloaderBase : IMusicDownload, IPlaylistDownload
    {
        private string _location;

        protected string Location
        {
            get
            {
                if (_location == null)
                    return "C:\\";
                return _location;
            }
            set { _location = value; }
        }

        public abstract Music GetMusicInfo(string url);
        public abstract IEnumerable<Music> GetPlaylistInfo(string url);

        protected virtual void Download(string url, MusicType type = MusicType.Music, string location = null)
        {
            if (location == null)
            {
                location = Location;
            }

            switch (type)
            {
                case MusicType.Music:
                    DownloadMusic(url, location);
                    break;
                case MusicType.Playlist:
                    DownloadPlaylist(url, location);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public void DownloadMusic(string url, string location = null)
        {
            var musicInfo = GetMusicInfo(url);
            DownloadMusic(musicInfo, location);
        }

        void DownloadMusic(Music music, string location)
        {
            if (music != null && music.Sources.Count > 0)
            {
                var urlMusic = music.Sources.OrderByDescending(x =>
                {
                    int number;
                    return int.TryParse(x.Quality, out number) ? int.Parse(x.Quality) : 0;
                }).First().Link;
                DownloadFile(urlMusic, location, music.Name);
            }
        }

        protected void DownloadPlaylist(string url, string location = null)
        {
            var playlistInfo = GetPlaylistInfo(url);
            foreach (var music in playlistInfo)
            {
                DownloadMusic(music, location);
            }
        }

        private void DownloadFile(string url, string location, string fileName)
        {
            if (location == null)
                location = Location;
            if (!Directory.Exists(location))
            {
                Directory.CreateDirectory(Path.Combine(location));
            }
            var filePath = Path.Combine(location, fileName);

            using (var wc = new WebClient())
            {
                var fileBytes = wc.DownloadData(url);

                var fileType = wc.ResponseHeaders[HttpResponseHeader.ContentType];

                if (fileType != null)
                {
                    switch (fileType)
                    {
                        case "image/jpeg":
                            filePath += ".jpg";
                            break;
                        case "image/gif":
                            filePath += ".gif";
                            break;
                        case "image/png":
                            filePath += ".png";
                            break;
                        case "audio/mpeg":
                            filePath += ".mp3";
                            break;
                        default:
                            break;
                    }

                    File.WriteAllBytes(filePath, fileBytes);
                }
            }
        }
    }
}