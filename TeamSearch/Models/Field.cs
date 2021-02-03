using System.Collections.Generic;

namespace TeamSearch.Models
{
    public class Field
    {
        public int id { get; set; }

        public string name { get; set; }

        public ICollection<FieldLanguage> fieldLanguages { get; set; }

    }
}