using System.Collections.Generic;

namespace TeamSearch.Models
{
    public class Language
    {
        public int id { get; set; }

        public string name { get; set; }

        public List<UserLanguage> userLanguage { get; set; }

        public List<FieldLanguage> fieldLanguage { get; set; }
    }
}