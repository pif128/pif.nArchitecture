using pif.Core.Security.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.RentACar.Application.Features.Auths.Dtos
{
	public class KodlamaUserForRegisterDto: UserForRegisterDto
	{
		public string UserName { get; set; }
	}
}
