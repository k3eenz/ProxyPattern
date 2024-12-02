using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    public class Proxy : ISubject
    {
        private RealSubject _realSubject;
        private Dictionary<string, (string Response, DateTime Expiration)> _cache;
        List<string> allowedRoles = new List<string> { "Admin", "Support" };
        private TimeSpan _cacheDuration;
        private string _role;
        public Proxy(RealSubject realSubject, string Role)
        {
            _realSubject = realSubject;
            _cache = new Dictionary<string, (string, DateTime)>();
            _cacheDuration = TimeSpan.FromMinutes(1);
            _role = Role;
        }

        public string Request(string request)
        {
            if (!CheckAccess())
            {
                return "Доступ запрещен.";
            }
            if (_cache.TryGetValue(request, out var cachedEntry))
            {
                if (cachedEntry.Expiration > DateTime.Now)
                {
                    return $"Кэшированный результат: \n{cachedEntry.Response}";
                }
                _cache.Remove(request);
            }
            string response = _realSubject.Request(request);
            _cache[request] = (response, DateTime.Now.Add(_cacheDuration));
            return response;
        }
        private bool CheckAccess()
        {
            return allowedRoles.Contains(_role);
        }
    }
}
