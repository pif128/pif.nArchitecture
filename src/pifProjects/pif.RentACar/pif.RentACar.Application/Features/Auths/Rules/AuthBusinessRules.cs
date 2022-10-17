using pif.Core.CrossCuttingConcerns.Exceptions;
using pif.Core.Security.Entities;
using pif.RentACar.Application.Services.Repositories;

namespace pif.RentACar.Application.Features.Auths.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task EmailCanNotBeDuplicatedWhenRegistered(string email)
        {
            User? user = await _userRepository.GetAsync(u=>u.Email==email);
            if (user != null) throw new BusinessException("Mail already exists");

        }
    }
}
