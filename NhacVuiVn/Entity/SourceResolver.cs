using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entity;

namespace NhacVuiVn.Entity
{
    public class SourceResolver : IValueResolver<MusicDto, Music, ICollection<Source>>
    {
        public ICollection<Source> Resolve(MusicDto source, Music destination, ICollection<Source> destMember, ResolutionContext context)
        {
            var sources = new List<Source>
            {
                new Source()
                {
                    Quality = source.Bitrate,
                    Link = source.Link
                }
            };
            return sources;
        }
    }
}
