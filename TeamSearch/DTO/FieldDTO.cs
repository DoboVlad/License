using System.Collections.Generic;

namespace TeamSearch.DTO
{
    public class FieldDTO
    {
        public int Id { get; set; }

        public string name { get; set; }

        public ICollection<LanguageDTO> language { get; set; }
    }
}