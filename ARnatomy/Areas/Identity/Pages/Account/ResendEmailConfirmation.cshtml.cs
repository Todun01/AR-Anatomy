// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ARnatomy.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace ARnatomy.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ResendEmailConfirmationModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly INotyfService _notyf;
        private readonly ILogger<ConfirmEmailModel> _logger;

        public ResendEmailConfirmationModel(
            UserManager<ApplicationUser> userManager, 
            IEmailSender emailSender,
            INotyfService notyf,
            ILogger<ConfirmEmailModel> logger)
        {
            _userManager = userManager;
            _emailSender = emailSender;
            _notyf = notyf;
            _logger = logger;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.FindByEmailAsync(Input.Email);
            if (user == null)
            {
                _notyf.Error("Email does not exist");
                return Page();
            }
            if(await _userManager.IsEmailConfirmedAsync(user))
            {
                _notyf.Information("Your email is already confirmed. Please log in");
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }
            var userId = await _userManager.GetUserIdAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            _logger.LogInformation(code);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { userId = userId, code = code },
                protocol: Request.Scheme);
            
            try
            {
                var emailTemplate = System.IO.File.ReadAllText("wwwroot/email-templates/confirm-email.html");
                var emailBody = emailTemplate.Replace("{{CONFIRM_URL}}", HtmlEncoder.Default.Encode(callbackUrl));
                await _emailSender.SendEmailAsync(Input.Email, "Confirm your email", emailBody);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Email sending failed: {ex.Message}");
                _notyf.Error("There was a problem sending the confirmation email.");
                //ModelState.AddModelError(string.Empty, "There was a problem sending the confirmation email.");
                return Page();
            }
            
            _notyf.Success("Verification email sent. Please check your email");
            return Page();
        }
    }
}
