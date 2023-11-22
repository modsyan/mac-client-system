using MacClientSystem.Application.Common.Interfaces;
using MacClientSystem.Domain.Entities;
using Microsoft.Extensions.DependencyInjection.TripTickOrders.Query;

namespace MacClientSystem.Application.TripTickOrders.Query;

public record GetTripTickOrderListQuery : IRequest<TripTickOrderVm>;

public class GetTripTickOrderListQueryHandler
    (IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetTripTickOrderListQuery, TripTickOrderVm>
{
    public async Task<TripTickOrderVm> Handle(GetTripTickOrderListQuery request, CancellationToken cancellationToken)
    {
        var vm = new TripTickOrderVm();

        var currentUserId = new Guid();
        
        var order = await context.TripTickOrders
            .Where(o => o.ApplicationUserId == currentUserId)
            .ProjectTo<TripTickOrderDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        if (order == null)
        {
            throw new NotFoundException(nameof(TripTickOrder), currentUserId.ToString());
        }

        vm.TripTickOrders = order;
        return vm;
    }
}
