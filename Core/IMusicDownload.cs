﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entity;

namespace Core
{
    interface IMusicDownload
    {
        Music GetMusicInfo(string url);
    }
}
