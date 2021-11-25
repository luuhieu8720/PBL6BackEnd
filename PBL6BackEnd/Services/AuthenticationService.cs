using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using PBL6BackEnd.Config;
using PBL6BackEnd.DTO.AuthDTO;
using PBL6BackEnd.DTO.UserDTO;
using PBL6BackEnd.Repository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL6BackEnd.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly TokenConfig tokenConfig;

        private readonly IHttpContextAccessor httpContextAccessor;

        private readonly IAuthenticationRepository authenticationRepository;

        public AuthenticationService(TokenConfig tokenConfig,
            IHttpContextAccessor httpContextAccessor,
            IAuthenticationRepository authenticationRepository)
        {
            this.tokenConfig = tokenConfig;
            this.httpContextAccessor = httpContextAccessor;
            this.authenticationRepository = authenticationRepository;
        }

        public AuthenUser CurrentUser => ((UserClaimsPrincipal)httpContextAccessor.HttpContext.User).AuthenUser;

        public Guid CurrentUserId => CurrentUser.Id;

        public async Task<TokenResponse> Login(LoginForm loginForm)
        {
            var user = await authenticationRepository.Login(loginForm);

            var authenUser = new AuthenUser(user);

            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tokenConfig.Key));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var tokenString = new JwtSecurityToken(tokenConfig.Issuer, tokenConfig.Audience, claims: authenUser.GetClaims(), signingCredentials: signingCredentials);

            return new TokenResponse()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(tokenString),
                UserId = authenUser.Id,
                FirstName = authenUser.FirstName,
                LastName = authenUser.LastName,
                Username = authenUser.Username
            };
        }
    }
}
