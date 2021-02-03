using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace TeamSearch.Models
{
    public class User: IdentityUser<int>
    {
        public string firstName { get; set; }

        public string lastName { get; set; }

        public ICollection<UserLanguage> programmingLanguages { get; set; }

        public ICollection<UserTeam> userTeam { get; set; }

        public ICollection<UserRole> userRole { get; set; }
    }
}
