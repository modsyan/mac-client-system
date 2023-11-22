using MacClientSystem.Application.Common.Interfaces;
using MacClientSystem.Domain.Entities;

namespace MacClientSystem.Application.LicenseOrders.Query;

public record GetLicenseOrderQuery(int Id) : IRequest<LicenseOrderDto>;

public class GetLicenseOrderQueryHandler
    (IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetLicenseOrderQuery, LicenseOrderDto>
{
    public async Task<LicenseOrderDto> Handle(GetLicenseOrderQuery request, CancellationToken cancellationToken)
    {
        var vm = new LicenseOrderVm();

        var order = await context.LicenseOrders
            .Where(o => o.Id == request.Id)
            .ProjectTo<LicenseOrderDto>(mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(cancellationToken);

        if (order == null)
        {
            throw new NotFoundException(nameof(LicenseOrder), request.Id.ToString());
        }

        // vm.LicenseOrders = order;
        // return vm;
        return order;
    }
}
