using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamSearch.Models
{
    public class FieldLanguage
    {
        public int Id { get; set; }
        public int FieldId { get; set; }
        public Field Field { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
