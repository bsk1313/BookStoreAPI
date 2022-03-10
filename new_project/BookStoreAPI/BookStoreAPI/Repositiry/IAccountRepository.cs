using BookStoreAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace BookStoreAPI.Repositiry
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignUpModel signUpModel);
        Task<string> LoginAsync(SignInModel signInModel);
    }
}
