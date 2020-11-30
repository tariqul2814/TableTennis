using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace TableTennis.DataAccess.DBContext
{
    public class ApplicationUser : IdentityUser<int>
    {

    }
    public class ApplicationRole : IdentityRole<int>
    {
        public ApplicationRole(string Role) : base(Role)
        {

        }
        public ApplicationRole() : base()
        {

        }
    }
}
