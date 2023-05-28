using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProniaAB103.Models;
using ProniaAB103.Utilities.Enums;
using ProniaAB103.ViewModels;

namespace ProniaAB103.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM newUser)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            AppUser user = new AppUser
            {
                Name= newUser.Name,
                Surname=newUser.Surname,
                Email=newUser.Email,
                UserName=newUser.Username

            };
            
           IdentityResult result= await _userManager.CreateAsync(user, newUser.Password);
            if (!result.Succeeded)
            {
               foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }
            await _userManager.AddToRoleAsync(user,UserRole.Member.ToString());
            await _signInManager.SignInAsync(user, false);
            return RedirectToAction("Index","Home");
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM user,string ReturnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            AppUser existed = await _userManager.FindByEmailAsync(user.UsernameOrEmail);
            if (existed==null)
            {
                existed = await _userManager.FindByNameAsync(user.UsernameOrEmail);
                if (existed==null)
                {
                    ModelState.AddModelError(string.Empty,"Username, Email or Password is not correct");
                    return View();
                }
                
            }

            
            var result=await _signInManager.PasswordSignInAsync(existed, user.Password, user.IsRemember, true);
            if (result.IsLockedOut)
            {
                ModelState.AddModelError(string.Empty, "Login is not available now, please try again later");
                return View();
            }
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Username, Email or Password is not correct");
                return View();
            }

            if (ReturnUrl!=null)
            {
                return Redirect(ReturnUrl);

            }
            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }


        public async Task<IActionResult> CreateRoles()
        {
            foreach (var role in Enum.GetValues(typeof(UserRole)))
            {
                if (!(await _roleManager.RoleExistsAsync(role.ToString())))
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name = role.ToString() });
                }
               
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
