using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Identity.Controllers
{
    /// <summary>
    /// Illustrates Authentication and 
    /// </summary>
    [Authorize]
    public class SecretController : Controller
    {
        public ContentResult Secret()
        {
            return Content("This is SECRET content!");
        }

        [AllowAnonymous]
        public ContentResult Overt()
        {
            return Content("This isn't secret content.");
        }
	}
}