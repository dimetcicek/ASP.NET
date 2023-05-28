using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApp.Models.Entities;
using WebApp.ViewModels;

namespace WebApp.Helpers.Services;

public class AuthenticationService
{

    private readonly UserManager<UserEntity> _userManager;
    private readonly SignInManager<UserEntity> _signInManager;
    private readonly AddressService _addressService;

    public AuthenticationService(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, AddressService addressService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _addressService = addressService;
    }

    public async Task<bool> RegisterAsync(RegisterViewModel viewModel)
    {
        try
        {
            var role = "user";

            var admins = await _userManager.GetUsersInRoleAsync("admin");

            // If we dont have any admins, make this user admin.
            if (admins.Count == 0)
            {
                role = "admin";
            }

            var result = await _userManager.CreateAsync(viewModel, viewModel.Password);

            if (result.Succeeded)
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == viewModel.Email);
                await _userManager.AddToRoleAsync(user!, role);

                var address = await _addressService.GetOrCreateAsync(viewModel);
                return await _addressService.AddUserAddress(user!.Id, address.Id);

            }
        }
        catch (Exception ex) 
        { 
            Debug.WriteLine(ex.Message);
        }

        return false;
    }



    public async Task<bool> LoginAsync(LoginViewModel viewModel)
    {
        try
        {
            var result = await _signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, viewModel.RememberMe, false);
            return result.Succeeded;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }


    public async Task<bool> LogoutAsync()
    {
        try
        {
            await _signInManager.SignOutAsync();
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }

}