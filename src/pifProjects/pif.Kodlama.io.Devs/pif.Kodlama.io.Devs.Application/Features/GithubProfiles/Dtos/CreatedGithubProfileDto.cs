using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Dtos
{
	public class CreatedGithubProfileDto
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public string GithubAddress { get; set; }
	}
}
