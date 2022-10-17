using pif.Core.Security.Entities;

namespace pif.Core.Security.JWT
{

	public interface ITokenHelper
	{
		AccessToken CreateToken(User user, IList<OperationClaim> operationClaims);

		RefreshToken CreateRefreshToken(User user, string ipAddress);
	}
}