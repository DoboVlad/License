using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamSearch.Models
{
    public class UserRole: IdentityUserRole<int>
    {
        public User user { get; set; }
        public Role role { get; set; }
    }
}
