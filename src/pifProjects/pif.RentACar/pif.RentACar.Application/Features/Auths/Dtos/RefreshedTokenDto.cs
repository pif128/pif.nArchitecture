using pif.Core.Security.Entities;
using pif.Core.Security.JWT;

namespace pif.RentACar.Application.Features.Auths.Dtos
{
    public class RefreshedTokenDto
    {
        public AccessToken AccessToken { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
}
