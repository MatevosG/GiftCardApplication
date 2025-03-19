using GiftCardSystem.Application.Dtoes;
using GiftCardSystem.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftCardSystem.Application.Features.Clients.Commands.LoginClient
{
    public class LoginClientCm : IRequest<ResponseModel>
    {
        public LoginClientDto LoginModel { get; set; }

        public LoginClientCm(LoginClientDto loginModel)
        {
            LoginModel = loginModel;
        }
    }
}
