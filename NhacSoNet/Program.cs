using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhacSoNet
{
    class Program
    {
        static void Main(string[] args)
        {
            var nhacSoClient = new NhacSoClient();
            var musicInfo = nhacSoClient.GetMusicInfo("http://nhacso.net/nghe-playlist/ngay-mua.XFhTVkBZbg==.html");
        }
    }
}
