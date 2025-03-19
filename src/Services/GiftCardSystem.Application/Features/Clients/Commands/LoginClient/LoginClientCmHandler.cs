using GiftCardSystem.Application.Authorization;
using GiftCardSystem.Application.Contracts;
using GiftCardSystem.Application.Exceptions;
using GiftCardSystem.Application.Models;
using GiftCardSystem.Application.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftCardSystem.Application.Features.Clients.Commands.LoginClient
{
    public class LoginClientCmHandler : IRequestHandler<LoginClientCm, ResponseModel>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IEncrypter _encrypter;
        private readonly IAuthentication _authentication;

        public LoginClientCmHandler(IClientRepository clientRepository, 
                                    IEncrypter encrypter, 
                                    IAuthentication authentication)
        {
            _clientRepository = clientRepository;
            _encrypter = encrypter;
            _authentication = authentication;
        }

        public async Task<ResponseModel> Handle(LoginClientCm request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetQuery(x=>x.Email == request.LoginModel.Email).FirstOrDefaultAsync();
            if(client == null)
                throw new CustomException("Invalid email or password");

            if (!_encrypter.GetHash(request.LoginModel.Password, client.Salt).Equals(client.Password))
                throw new CustomException("Invalid email or password");

            var token = _authentication.CreateJwtToken(client);
            return new ResponseModel(token);
        }
    }
}
