using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using BCrypt;
using MadrageBackEndChallenge.Business.Dtos;
using MadrageBackEndChallenge.Business.Validators;
using MadrageBackEndChallenge.Domain;
using MadrageBackEndChallenge.Domain.Exceptions;
using MadrageBackEndChallenge.Persistence.Daos;
using Microsoft.IdentityModel.Tokens;

namespace MadrageBackEndChallenge.Business
{
    internal class UserService : IUserService
    {
        private readonly SigningCredentials _signingCredentials;
        private readonly IUserDao _dao;
        private readonly SignInDtoValidator _signInDtoValidator;
        private readonly UserSaveDtoValidator _userSaveDtoValidator;

        public UserService(SigningCredentials signingCredentials, IUserDao dao)
        {
            _signingCredentials = signingCredentials;
            _dao = dao;
            _signInDtoValidator = new SignInDtoValidator();
            _userSaveDtoValidator = new UserSaveDtoValidator();
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
        
        public object[] All(int? index, int? limit)
        {
            // ReSharper disable once CoVariantArrayConversion
            return _dao.All(index, limit).Select(e => new
            {
                e.Id,
                e.Name,
                e.Email
            }).ToArray();
        }
        public object Get(int id)
        {
            var user = _dao.Get(id);
            return new
            {
                user.Name,
                user.Email,
                Menus = _dao.GetMenusByUserId(id).BuildMenuTreeNode()
            };
        }

        public void Save(IUserSaveDto dto)
        {
            _userSaveDtoValidator.Check(dto);
            
            if (dto.Id != null)
            {
                var user = _dao.Get(dto.Id.Value);
                user.Name = dto.Name;
                _dao.Update(user);  
            }
            else
            {
                if (_dao.HasEmail(dto.Email))
                {
                    throw new EmailAlreadyExistsException();
                }
                
                _dao.Create(new User
                {
                    Name = dto.Name,
                    Email = dto.Email,
                    Password = BCryptHelper.HashPassword(dto.Password, BCryptHelper.GenerateSalt())
                });  
            }
        }

        public void Delete(int id)
        {
            _dao.Delete(id);
        }
    }
}