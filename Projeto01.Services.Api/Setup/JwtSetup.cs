using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Projeto01.Services.Api.Setup
{
    public class JwtSetup
    {
        public static void AddJwtSetup(WebApplicationBuilder builder)
        {
            //capturar o valor da secretKey
            var secretKey = builder.Configuration.GetValue<string>("JwtSettings:SecretKey");

            var key = Encoding.ASCII.GetBytes(secretKey);

            builder.Services.AddAuthentication(
               auth =>
               {
                   auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                   auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
               }
               ).
               AddJwtBearer(
                   bearer =>
                   {
                       bearer.RequireHttpsMetadata = false;
                       bearer.SaveToken = true;
                       bearer.TokenValidationParameters = new TokenValidationParameters
                       {
                           ValidateIssuerSigningKey = true,
                           IssuerSigningKey = new SymmetricSecurityKey(key),
                           ValidateIssuer = false,
                           ValidateAudience = false
                       };
                   }
               );
        }
    }
}

