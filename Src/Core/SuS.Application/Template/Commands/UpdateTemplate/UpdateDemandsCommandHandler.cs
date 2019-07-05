using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SuS.Persistence;

namespace SuS.Application.Template.Commands.UpdateTemplate
{
    public class UpdateTemplateCommandHandler : IRequestHandler<UpdateTemplateCommand, Unit>
    {
        private readonly SupplierDbContext _context;

        public UpdateTemplateCommandHandler(SupplierDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateTemplateCommand request,
            CancellationToken cancellationToken)
        {
//            var tmp = _context.TemplateEntity.SingleOrDefault(x => x.Id == request.Id);
//            if(tmp!=null) tmp.Value = request.Value;
//            await _context.SaveChangesAsync(cancellationToken);
//            return Unit.Value;
            return Unit.Value;
        }
    }
}