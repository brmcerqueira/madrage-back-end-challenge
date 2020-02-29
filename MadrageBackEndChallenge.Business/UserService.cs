using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Security.Principal;
using BCrypt;
using MadrageBackEndChallenge.Business.Dtos;
using MadrageBackEndChallenge.Business.Validators;
using MadrageBackEndChallenge.Persistence.Daos;
using Microsoft.IdentityModel.Tokens;

namespace MadrageBackEndChallenge.Business
{
    public class UserService
    {
        private readonly SigningCredentials _signingCredentials;
        private readonly IUserDao _dao;
        private readonly SignInDtoValidator _signInDtoValidator;

        public UserService(SigningCredentials signingCredentials, IUserDao dao)
        {
            _signingCredentials = signingCredentials;
            _dao = dao;
            _signInDtoValidator = new SignInDtoValidator();
        }
        
        public string SignIn(ISignInDto dto)
        {
            _signInDtoValidator.Check(dto);

            var user = _dao.GetUserByEmail(dto.Email);

            if (user == null || !BCryptHelper.CheckPassword(dto.Password, user.Password))
            {
                throw new AuthenticationException();
            }
            
            var handler = new JwtSecurityTokenHandler();

            var now = DateTime.Now;

            return handler.WriteToken(handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = "MadrageBackEndChallengeIssuer",
                Audience = "MadrageBackEndChallengeAudience",
                SigningCredentials = _signingCredentials,
                Subject = new ClaimsIdentity(new GenericIdentity(user.Name, "SignIn"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email)
                    }
                ),
                NotBefore = now,
                Expires = now + TimeSpan.FromDays(3)
            }));
        }
    }
}