using MacClientSystem.Application.Common.Interfaces;
using MacClientSystem.Domain.Entities;

namespace MacClientSystem.Application.LicenseOrders.Query;

public record GetLicenseOrderListQuery : IRequest<LicenseOrderVm>;

public class GetLicenseOrderListQueryHandler
    (IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetLicenseOrderListQuery, LicenseOrderVm>
{
    public async Task<LicenseOrderVm> Handle(GetLicenseOrderListQuery request, CancellationToken cancellationToken)
    {
        var vm = new LicenseOrderVm();

        Guid currentUserId = new Guid();

        var order = await context.LicenseOrders
            .Where(o => o.ApplicationUserId == currentUserId)
            .ProjectTo<LicenseOrderDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        if (order == null)
        {
            throw new NotFoundException(nameof(LicenseOrder), currentUserId.ToString());
        }

        vm.LicenseOrders = order;
        return vm;
    }
}
