using pif.Core.Persistence.Paging;
using pif.Kodlama.io.Devs.Application.Features.OperationClaims.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Application.Features.OperationClaims.Models
{
	public class OperationClaimListModel : BasePageableModel
	{
		public IList<GetListOperationClaimDto> Items { get; set; }
	}
}
