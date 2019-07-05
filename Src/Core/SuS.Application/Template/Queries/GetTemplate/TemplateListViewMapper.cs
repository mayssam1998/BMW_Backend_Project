using AutoMapper;
using SuS.Domain.Entities.TempSchema;

namespace SuS.Application.Template.Queries.GetTemplate
{   
    public class TemplateListViewMapper : Profile
    {
        public TemplateListViewMapper()
        {
            CreateMap<TemplateEntity, TemplateLookupModel>()
                .ReverseMap();
        }
    }
}