using pif.Core.Security.Entities;
using pif.Core.Security.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Domain.Entities
{
	public class KodlamaUser:User
	{
		public string UserName { get; set; }
		public virtual ICollection<GithubProfile> GithubProfiles { get; set; }

		public KodlamaUser()
		{

		}

		public KodlamaUser(int id,string userName,string firstName,string lastName,string email, byte[] passwordSalt, byte[] passwordHash, bool status)
		{
			Id = id;
			UserName = userName;
			FirstName = firstName;
			LastName = lastName;
			Email = email;
			PasswordHash = passwordHash;
			PasswordSalt = passwordSalt;
			Status = status;
		}
	}
}
