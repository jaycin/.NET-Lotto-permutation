using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JaysSpace
{
    public class Context : IdentityDbContext<IdentityUser>
    {
        public Context()
            : base("AuthContext")
        {

        }
    }
}