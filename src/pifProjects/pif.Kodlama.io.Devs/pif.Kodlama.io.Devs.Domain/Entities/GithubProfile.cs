using pif.Core.Persistence.Repositories;
using pif.Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Domain.Entities
{
	public class GithubProfile : Entity
	{
		public string GithubAddress { get; set; }
		public int UserId { get; set; }
		public virtual User? User { get; set; }


		public GithubProfile()
		{
		}
		public GithubProfile(int id, int userId, string githubAddress)
		{
			Id = id;
			UserId = userId;
			GithubAddress = githubAddress;
		}

	}
}
