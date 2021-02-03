using System.Collections.Generic;

namespace TeamSearch.Models
{
    public class Language
    {
        public int id { get; set; }

        public string name { get; set; }

        public ICollection<UserLanguage> userLanguage { get; set; }

        public ICollection<FieldLanguage> fieldLanguage { get; set; }
    }
}