using CharityClinic.Data.Model;

namespace CharityClinic.Services
{
    public interface IAuthService
    {
        Task<AuthResult> Login(LoginViewModel user);
        Task<AuthResult> Register(RegisterViewModel user);
        Task<AuthResult> ChangePassword(ChangePasswordViewModel model);
        Task Logout();
    }
}
