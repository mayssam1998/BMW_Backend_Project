using MediatR;

namespace SuS.Application.Template.Commands.UpdateTemplate
{
    public class UpdateTemplateCommand : IRequest
    {
        public long Id { get; set; }
        public string Value { get; set; }
    }
}
