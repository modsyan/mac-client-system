using MacClientSystem.Application.Common.Interfaces;

namespace MacClientSystem.Application.TripTickOrders.Query;

public record GetUserTripTickOrderQuery(string ExternalUserId) : IRequest<TripTickOrderVm>;

public class GetUserTripTickOrderQueryHandler
    (IApplicationDbContext context /*, IMapper mapper*/) : IRequestHandler<GetUserTripTickOrderQuery, TripTickOrderVm>
{
    public async Task<TripTickOrderVm> Handle(GetUserTripTickOrderQuery request, CancellationToken cancellationToken)
    {
        var order = await context.TripTickOrders
            .Where(x => x.ExternalUserId == request.ExternalUserId)
            .Include(t => t.VehicleRegistrationCopyDocument)
            .Include(t => t.PersonalGovernmentalIdentityDocument)
            .Include(t => t.VehicleType)
            .Include(t => t.PassportDocument)
            // .ProjectTo<TripTickOrderDto>(mapper.ConfigurationProvider)
            .Select(t=>t.MapToDto())
            .ToListAsync(cancellationToken);

        return new TripTickOrderVm { TripTickOrders = order };
    }
}
