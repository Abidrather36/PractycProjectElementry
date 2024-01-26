using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Practyc.Application.Abstraction.IJWT;
using Practyc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Practyc.Infrastructure.JWT
{
    public class JwtProvider : IJwtProvider
    {
        private readonly IConfiguration configuration;

        public JwtProvider(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string GenerateToken(User user)
        {
            
                var descriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new List<Claim>
                {
                    new Claim("UserId", user.Id.ToString()),
                    new Claim("UserName", user.Username),
                    new Claim("Email", user.Email),
                    new Claim("Role", user.UserRole.ToString())
                }),
                    Expires = DateTime.Now.AddHours(1),
                    Issuer = configuration["Jwt:Issuer"],
                    Audience = configuration["Jwt:Audience"],
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration
                    ["Jwt:Key"]!)), SecurityAlgorithms.HmacSha256),


                };
                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(descriptor);
                return handler.WriteToken(securityToken);
            }
        }
    }

