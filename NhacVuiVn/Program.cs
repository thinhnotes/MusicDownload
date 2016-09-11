using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhacVuiVn
{
    class Program
    {
        static void Main(string[] args)
        {
            var nhacVuiVnClient = new NhacVuiVnClient();
            var playlistInfo = nhacVuiVnClient.GetPlaylistInfo("http://nhac.vui.vn/album-tuyen-tap-nhung-ca-khuc-hay-nhat-cua-ca-si-minh-thuan-minh-thuan-a55374p650.html");
        }
    }
}
