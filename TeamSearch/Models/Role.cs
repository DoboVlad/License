using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamSearch.Models
{
    public class Role: IdentityRole<int>
    {
        public ICollection<UserRole> userRole { get; set; }
    }
}
