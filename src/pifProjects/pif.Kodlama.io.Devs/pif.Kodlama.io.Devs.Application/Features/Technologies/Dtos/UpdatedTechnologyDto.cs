namespace pif.Kodlama.io.Devs.Application.Features.Technologies.Dtos
{
	public class UpdatedTechnologyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
		public int? ProgrammingLanguageId { get; set; }
		public string? ProgramminLanguageName { get; set; }
	}
}
