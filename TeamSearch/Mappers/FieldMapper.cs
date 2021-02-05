using TeamSearch.DTO;
using TeamSearch.Models;
using AutoMapper;
using System.Linq;

namespace TeamSearch.Mappers
{
    public class FieldMapper: Profile
    {
        public FieldMapper()
        {
            CreateMap<Field, FieldDTO>().ForMember(dto => dto.language,
            opt => opt.MapFrom(x => x.fieldLanguages.Select(y => y.Language).ToList()));
            CreateMap<Language, LanguageDTO>();
        }
    }
}