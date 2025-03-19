using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftCardSystem.Application.Authorization
{
    public class AuthOptions
    {
        public string Key { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Lifetime { get; set; }
        public int ExpirationPeriodMinute { get; set; }
    }
}
