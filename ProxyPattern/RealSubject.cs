using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    public class RealSubject : ISubject
    {
        public string Request(string request)
        {
            return $"RealSubject: обработка запроса \"{request}\".";
        }
    }
}
