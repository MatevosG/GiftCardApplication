using AutoMapper;
using GiftCardSystem.Application.Authorization;
using GiftCardSystem.Application.Constants;
using GiftCardSystem.Application.Contracts;
using GiftCardSystem.Application.Exceptions;
using GiftCardSystem.Application.Models;
using GiftCardSystem.Application.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace GiftCardSystem.Application.Features.Clients.Commands.RegisterClient
{
    public class RegisterClientCmHandler : IRequestHandler<RegisterClientCm, ResponseModel>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IEncrypter _encrypter;
        private readonly IAuthentication _authentication;
        private IMapper _mapper;

        public RegisterClientCmHandler(IClientRepository clientRepository, 
                                       IEncrypter encrypter, 
                                       IAuthentication authentication, 
                                       IMapper mapper)
        {
            _clientRepository = clientRepository;
            _encrypter = encrypter;
            _authentication = authentication;
            _mapper = mapper;
        }

        public async Task<ResponseModel> Handle(RegisterClientCm request, CancellationToken cancellationToken)
        {
            if(!request.ClientDto.Password.Equals(request.ClientDto.ConfirmPassword))
                throw new CustomException("Passwords do not match");

            Regex Regex = new Regex(ConstantsItems.EmailRegex);
            if (!Regex.IsMatch(request.ClientDto.Email))
                throw new CustomException("Invalid email format");

            Regex = new Regex(ConstantsItems.PhoneNumberRegex);

            if (!Regex.IsMatch(request.ClientDto.PhoneNumber.Replace(" ", "")))
                throw new CustomException("Invalid phonenumber format");

            var client = await _clientRepository.GetQuery(x => x.Email == request.ClientDto.Email).FirstOrDefaultAsync();
            if (client != null)
                throw new CustomException("Email already exists");

            client = _mapper.Map(request.ClientDto, client);
            client.Salt = _encrypter.GetSalt();
            client.Password = _encrypter.GetHash(client.Password, client.Salt);
            client = await _clientRepository.AddAsync(client);
            return new ResponseModel(_authentication.CreateJwtToken(client));
        }
    }
}
