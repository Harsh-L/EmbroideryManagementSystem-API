using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmbroidaryManagementSystem
{
    public class jwtSettings
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecurityKey { get; set; }
        public int ExpiresTime { get; set; }
        public string DefaultAuthenticateScheme { get; set; }
    }
}
