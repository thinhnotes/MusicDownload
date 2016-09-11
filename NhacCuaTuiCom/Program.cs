using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entity;

namespace NhacCuaTuiCom
{
    class Program
    {
        static void Main(string[] args)
        {
            var nhacCuaTuiClient = new NhacCuaTuiClient();
            nhacCuaTuiClient.GetMusicInfo("http://www.nhaccuatui.com/bai-hat/mot-ai-do-khac-the-men-ft-nguyen-hoang-duy.u1rEGz5pQFeD.html");
            //nhacCuaTuiClient.GetMusicInfo("")
        }
    }
}
