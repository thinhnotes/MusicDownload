using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicMp3ZingVn
{
    class Program
    {
        static void Main(string[] args)
        {
            var mp3ZingVnClient = new Mp3ZingVnClient();
            mp3ZingVnClient.DownloadMusic("http://mp3.zing.vn/bai-hat/Hay-Ra-Khoi-Nguoi-Do-Di-Phan-Manh-Quynh/ZW77F8E0.html", @"D:\test");
        }
    }
}
