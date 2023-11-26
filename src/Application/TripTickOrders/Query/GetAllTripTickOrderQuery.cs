using MacClientSystem.Application.Common.Interfaces;
using MacClientSystem.Domain.Entities;

namespace MacClientSystem.Application.TripTickOrders.Query;

public record GetAllTripTickOrderQuery : IRequest<TripTickOrderVm>;

public class GetTripTickOrderListQueryHandler
    (IApplicationDbContext context) : IRequestHandler<GetAllTripTickOrderQuery, TripTickOrderVm>
{
    public async Task<TripTickOrderVm> Handle(GetAllTripTickOrderQuery request, CancellationToken cancellationToken)
    {
        var order =
            (await context.TripTickOrders
                .Where(o => o.AccountId == 1) //Account 1 for Firebase Account TODO: Remove this
                .Include(t => t.VehicleRegistrationCopyDocument)
                .Include(t => t.PersonalGovernmentalIdentityDocument)
                .Include(t => t.VehicleType)
                .Include(t => t.PassportDocument)
                // .ProjectTo<TripTickOrderDto>(mapper.ConfigurationProvider) //TODO: disable projection for now
                .Select(t => t.MapToDto())
                .ToListAsync(cancellationToken));


        return new TripTickOrderVm { TripTickOrders = order };
    }
}
