using GiftCardSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GiftCardSystem.Application.Authorization
{
    public interface IAuthentication
    {
        public string CreateJwtToken(Client client);
    }
}
