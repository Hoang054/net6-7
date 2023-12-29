using Blazored.LocalStorage;
using CharityClinic.Data.Model;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Recruit.Server.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Web.Helpers;

namespace CharityClinic.Services
{
    public class AuthService : IAuthService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorageService;
        private readonly ApplicationDbContext applicationDbContext;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ITokenService tokenService;
        public AuthService(AuthenticationStateProvider authenticationStateProvider,
            ILocalStorageService localStorageService,
            ApplicationDbContext applicationDbContext,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ITokenService tokenService)
        {
            _authenticationStateProvider = authenticationStateProvider;
            _localStorageService = localStorageService;
            this.applicationDbContext = applicationDbContext;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenService = tokenService;
        }

        public async Task<AuthResult> Login(LoginViewModel user)
        {
            //var response = await _httpClient.PostAsync("api/Accounts/Login", new StringContent(dataJson, Encoding.UTF8, "application/json"));
            //var loginResult = JsonSerializer.Deserialize<AuthResult>(await response.Content.ReadAsStringAsync(),
            //    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            //if (!response.IsSuccessStatusCode)
            //{
            //    return loginResult ?? new AuthResult();
            //}
            var loginResult = await LoginAsync(user.UserId, user.Password);
            if(loginResult.Errors != null)
            {
                return loginResult;
            }
            //await _localStorageService.SetItemAsync("authToken", loginResult?.Token);
            //await _localStorageService.SetItemAsync("RoleName", loginResult?.RoleName ?? string.Empty);
            await _localStorageService.SetItemAsync("UserId", user?.UserId ?? string.Empty);
            //((CustomAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(user.Email, loginResult?.UserID!);

            //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResult?.Token);

            return loginResult ?? new AuthResult();
        }

        public async Task<AuthResult> Register(RegisterViewModel user)
        {
            //var response = await _httpClient.PostAsJsonAsync("api/Accounts/Register", user);
            var authResult = await RegisterAsync(user.Email, user.Password, user.FullName);
            return authResult ?? new AuthResult();
        }

        public async Task Logout()
        {
            //await _localStorageService.RemoveItemAsync("authToken");
            //await _localStorageService.RemoveItemAsync("fullName");
            await _localStorageService.RemoveItemAsync("UserId");
            //((CustomAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
        }

        public async Task<AuthResult> ChangePassword(ChangePasswordViewModel model)
        {
            //var response = await _httpClient.PutAsJsonAsync("api/Accounts/ChangePassword", model);
            //var authResult = await response.Content.ReadFromJsonAsync<AuthResult>();

            //if (authResult?.Succeeded == true)
            //{
            //    await _localStorageService.SetItemAsync("authToken", authResult?.Token);
            //    await ((CustomAuthenticationStateProvider)_authenticationStateProvider).UpdateState();
            //}

            //return authResult ?? new AuthResult();
            return new AuthResult();
        }

        public async Task<AuthResult> LoginAsync(string userId, string password)
        {
            var user = await applicationDbContext.Users
                .Where(u => u.Email == userId)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return new AuthResult()
                {
                    Errors = new List<string>() { "Invalid email or password" }
                };
            }
            var passwordHasher = new PasswordHasher<object>();
            var passwordVerificationResult = passwordHasher.VerifyHashedPassword(null, user.PasswordHash, password);

            if (passwordVerificationResult == PasswordVerificationResult.Success)
            {
                try
                {
                    var roles = await (from userInfo in applicationDbContext.Users
                                       join userGrp in applicationDbContext.UserRoles on userInfo.Id equals userGrp.UserId
                                       join role in applicationDbContext.Roles on userGrp.RoleId equals role.Id
                                       where userInfo.Email == userId
                                       select role.Name)
                                      .FirstOrDefaultAsync();

                    return new AuthResult()
                    {
                        Succeeded = true,
                        //Token = _tokenService.GenerateToken(email, user.FullName!),
                        UserID = userId,
                        RoleName = roles
                    };
                }
                catch (Exception e)
                {
                    // Xử lý ngoại lệ nếu cần thiết
                }
            }

            return new AuthResult()
            {
                Errors = new List<string>() { "Invalid email or password" }
            };
        }

        public async Task<AuthResult> RegisterAsync(string email, string password, string fullName)
        {
            var user = new IdentityUser() { UserName = fullName, Email = email, NormalizedEmail = email };
            var result = await userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                return new AuthResult()
                {
                    Succeeded = true,
                    Token = tokenService.GenerateToken(email, fullName),
                    UserID = user.UserName
                };
            }

            return new AuthResult()
            {
                Errors = result.Errors.Select(x => x.Description)
            };
        }
    }
}
