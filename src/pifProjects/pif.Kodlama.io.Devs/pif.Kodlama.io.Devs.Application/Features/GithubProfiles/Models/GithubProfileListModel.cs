using pif.Core.Persistence.Paging;
using pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Models
{
	public class GithubProfileListModel:BasePageableModel
	{
		public IList<GetListGithubProfiledDto> Items { get; set; }
	}
}
