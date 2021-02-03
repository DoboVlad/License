using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamSearch.Models
{
    public class Team
    {
        public int Id { get; set; }

        public string name { get; set; }

        public string imageUrl { get; set; }

        public ICollection<UserTeam> members { get; set; }
    }
}
