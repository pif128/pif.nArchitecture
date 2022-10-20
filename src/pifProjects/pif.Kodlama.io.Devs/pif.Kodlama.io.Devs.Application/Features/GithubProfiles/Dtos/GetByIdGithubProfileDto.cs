namespace pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Dtos
{
	public class GetByIdGithubProfileDto
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public string UserName { get; set; }
		public string? GithubAddress { get; set; }
	}
}
