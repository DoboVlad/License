using System.Collections.Generic;

namespace TeamSearch.Models
{
    public class Field
    {
        public int id { get; set; }

        public string name { get; set; }

        public List<FieldLanguage> fieldLanguages { get; set; }

    }
}