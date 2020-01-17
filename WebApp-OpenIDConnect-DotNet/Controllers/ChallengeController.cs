using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp_OpenIDConnect_DotNet.Models;

namespace WebApp_OpenIDConnect_DotNet.Controllers
{
    [NotifyChallenge]
    public class ChallengeController : Controller
    {
        [Authorize(Policy = "B2C-Challenge-IdP")]
        public IActionResult IdentityProvider()
        {
            return View();
        }

        [Authorize(Policy = "B2C-Challenge-Admin")]
        public IActionResult CustomAdmin()
        {
            return View();
        }

        [Authorize(Policy = "B2C-Challenge-Rest")]
        public IActionResult RestAdmin()
        {
            return View();
        }

        [Authorize(Policy = "B2C-Challenge-Rest")]
        [Authorize(Policy = "B2C-Challenge-Admin")]
        public IActionResult SuperAdmin()
        {
            return View();
        }
    }
}