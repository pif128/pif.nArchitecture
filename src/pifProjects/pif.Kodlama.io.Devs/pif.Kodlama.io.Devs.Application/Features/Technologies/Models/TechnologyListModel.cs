using pif.Core.Persistence.Paging;
using pif.Kodlama.io.Devs.Application.Features.Technologies.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Application.Features.Technologies.Models
{
	public class ListTechnologyModel:BasePageableModel
	{
		public IList<GetListTechnologyDto> Items { get; set; }
	}
}
