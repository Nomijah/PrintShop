using System.IdentityModel.Tokens.Jwt;

namespace PrintShop.GlobalData.Data
{
    public class ClaimResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public ClaimResponse(JwtSecurityToken token)
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token);
            Expiration = token.ValidTo;
        }
    }
}
