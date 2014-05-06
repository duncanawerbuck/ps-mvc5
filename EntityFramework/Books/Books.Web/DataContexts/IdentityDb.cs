using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Books.Web.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Books.Web.DataContexts
{
    public class IdentityDb : IdentityDbContext<ApplicationUser>
    {
        public IdentityDb() : base("DefaultConnection") { }
    }
}