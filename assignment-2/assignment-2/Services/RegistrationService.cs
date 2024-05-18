using assignment_2.DTO;

namespace assignment_2.Services
{
    public interface IRegistrationService
    {
        void RegisterUser(UserDTO model);
    }

    public class RegistrationService : IRegistrationService
    {
        private readonly IUserService _userService;

        public RegistrationService(IUserService userService)
        {
            _userService = userService;
        }

        public void RegisterUser(UserDTO model)
        {
            _userService.AddUser(model);

        }
    }
}
