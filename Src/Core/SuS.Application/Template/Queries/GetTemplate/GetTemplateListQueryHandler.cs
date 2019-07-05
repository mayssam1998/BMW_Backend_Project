using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SuS.Persistence;

namespace SuS.Application.Template.Queries.GetTemplate
{
    public class GetTemplateListQueryHandler : IRequestHandler<GetTemplateListQuery, TemplateListViewModel>
    {
        private readonly SupplierDbContext _context;
        private readonly IMapper _mapper;

        public GetTemplateListQueryHandler(SupplierDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TemplateListViewModel> Handle(GetTemplateListQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<TemplateListViewModel>(_context.Country.ToList());
        }
    }
}