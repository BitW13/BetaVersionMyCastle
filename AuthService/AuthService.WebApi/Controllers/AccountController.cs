using AuthService.WebApi.Data;
using AuthService.WebApi.Models;
using IdentityServer4.Events;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.WebApi.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AuthUser> db;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IAuthenticationSchemeProvider _schemeProvider;
        private readonly IClientStore _clientStore;
        private readonly IEventService _events;

        public AccountController(UserManager<AuthUser> userManager, IIdentityServerInteractionService interaction, IAuthenticationSchemeProvider schemeProvider, IClientStore clientStore, IEventService events)
        {
            db = userManager;
            _interaction = interaction;
            _schemeProvider = schemeProvider;
            _clientStore = clientStore;
            _events = events;
        }

        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl)
        {
            var vm = await BuildLoginViewModelAsync(returnUrl);

            if (vm.IsExternalLoginOnly)
            {
                return RedirectToAction("Challenge", "External", new { provider = vm.ExternalLoginScheme, returnUrl });
            }

            return View(vm);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginInputModel model, string button)
        {
            var context = await _interaction.GetAuthorizationContextAsync(model.ReturnUrl);

            if (button != "login")
            {
                if (context != null)
                {
                    await _interaction.GrantConsentAsync(context, ConsentResponse.Denied);

                    if (await _clientStore.IsPkceClientAsync(context.ClientId))
                    {
                        return View("Redirect", new RedirectViewModel { RedirectUrl = model.ReturnUrl });
                    }

                    return Redirect(model.ReturnUrl);
                }
                else
                {
                    return Redirect("~/");
                }
            }

            if (ModelState.IsValid)
            {
                var user = await db.FindByNameAsync(model.Username);

                if (user != null)
                {
                    context = await _interaction.GetAuthorizationContextAsync(model.ReturnUrl);

                    if (ModelState.IsValid)
                    {
                        var isPasswordValid = await db.CheckPasswordAsync(user, model.Password);

                        if (isPasswordValid != false)
                        {
                            await _events.RaiseAsync(new UserLoginSuccessEvent(user.UserName, user.Id, user.Name));

                            AuthenticationProperties props = null;


                            await HttpContext.SignInAsync(user.Id, user.UserName, user.Name, props);

                            if (context != null)
                            {
                                if (await _clientStore.IsPkceClientAsync(context.ClientId))
                                {
                                    return View("Redirect", new RedirectViewModel { RedirectUrl = model.ReturnUrl });
                                }

                                return Redirect(model.ReturnUrl);
                            }

                            if (Url.IsLocalUrl(model.ReturnUrl))
                            {
                                return Redirect(model.ReturnUrl);
                            }
                            else if (string.IsNullOrEmpty(model.ReturnUrl))
                            {
                                return Redirect("~/");
                            }
                            else
                            {
                                throw new Exception("invalid return URL");
                            }
                        }

                        await _events.RaiseAsync(new UserLoginFailureEvent(model.Password, "invalid credentials"));

                        ModelState.AddModelError(string.Empty, "Неверный пароль");
                    }

                    var vmi = await BuildLoginViewModelAsync(model);

                    return View(vmi);
                }

                await _events.RaiseAsync(new UserLoginFailureEvent(model.Username, "invalid credentials"));

                ModelState.AddModelError(string.Empty, "Неверный E-mail");
            }

            var vm = await BuildLoginViewModelAsync(model);

            return View(vm);
        }

        [HttpGet]
        public IActionResult Logout(string logoutId)
        {
            return RedirectToAction("Login");
        }
        
        private async Task<LoginViewModel> BuildLoginViewModelAsync(string returnUrl)
        {
            var context = await _interaction.GetAuthorizationContextAsync(returnUrl);
            if (context?.IdP != null)
            {
                var local = context.IdP == IdentityServer4.IdentityServerConstants.LocalIdentityProvider;

                // this is meant to short circuit the UI and only trigger the one external IdP
                var vm = new LoginViewModel
                {
                    EnableLocalLogin = local,
                    ReturnUrl = returnUrl,
                    Username = context?.LoginHint,
                };

                if (!local)
                {
                    vm.ExternalProviders = new[] { new ExternalProvider { AuthenticationScheme = context.IdP } };
                }

                return vm;
            }

            var schemes = await _schemeProvider.GetAllSchemesAsync();

            var providers = schemes.Where(x => x.DisplayName != null || (x.Name.Equals(Microsoft.AspNetCore.Server.IISIntegration.IISDefaults.AuthenticationScheme, StringComparison.OrdinalIgnoreCase))
                )
                .Select(x => new ExternalProvider
                {
                    DisplayName = x.DisplayName,
                    AuthenticationScheme = x.Name
                }).ToList();

            var allowLocal = true;
            if (context?.ClientId != null)
            {
                var client = await _clientStore.FindEnabledClientByIdAsync(context.ClientId);
                if (client != null)
                {
                    allowLocal = client.EnableLocalLogin;

                    if (client.IdentityProviderRestrictions != null && client.IdentityProviderRestrictions.Any())
                    {
                        providers = providers.Where(provider => client.IdentityProviderRestrictions.Contains(provider.AuthenticationScheme)).ToList();
                    }
                }
            }

            return new LoginViewModel
            {
                AllowRememberLogin = true,
                EnableLocalLogin = allowLocal && true,
                ReturnUrl = returnUrl,
                Username = context?.LoginHint,
                ExternalProviders = providers.ToArray()
            };
        }

        private async Task<LoginViewModel> BuildLoginViewModelAsync(LoginInputModel model)
        {
            var vm = await BuildLoginViewModelAsync(model.ReturnUrl);
            vm.Username = model.Username;
            vm.RememberLogin = model.RememberLogin;
            return vm;
        }
    }
}