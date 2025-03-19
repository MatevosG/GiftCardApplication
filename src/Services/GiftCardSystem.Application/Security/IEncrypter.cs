using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftCardSystem.Application.Security
{
    public interface IEncrypter
    {
        string GetSalt();
        string GetHash(string password, string salt);
    }
}
