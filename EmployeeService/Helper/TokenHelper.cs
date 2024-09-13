using EmployeeService.DTOS;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeService.Helper
{
    /**public class TokenHelper
    {
    }**/
    public class TokenHelper
    {
        string key = "%#^$^&&)(*&^%$#&*&^&%&^$%^$%#$^^%$%%^#E^$R%^$";
        public string GenerateToken(EmployeeLoginDTO u)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                    new Claim("Role", "Employee"),
                    new Claim("Email",u.Email)
    };
            var token = new JwtSecurityToken("www.abc.com",
              "www.abc.com",
             claims,
             expires: DateTime.Now.AddMinutes(120),
             signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }

}
