using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THttpWebRequest;

namespace Core
{
    public class WebHttpClient:TWebRequest
    {
        public string LocationClient => Location;
    }
}
