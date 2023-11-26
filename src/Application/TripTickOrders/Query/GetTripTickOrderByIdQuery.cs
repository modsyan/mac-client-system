using MacClientSystem.Application.Common.Interfaces;
using MacClientSystem.Application.Common.Mappings;
using MacClientSystem.Domain.Entities;

namespace MacClientSystem.Application.TripTickOrders.Query;

public record GetTripTickOrderByIdQuery(int Id) : IRequest<TripTickOrderDto>;

public class GetTripTickOrderQueryHandler
    (IApplicationDbContext context /*, IMapper mapper*/) : IRequestHandler<GetTripTickOrderByIdQuery, TripTickOrderDto>
{
    // public async Task<TripTickOrderDto> Handle(GetTripTickOrderByIdQuery request, CancellationToken cancellationToken)
    public async Task<TripTickOrderDto> Handle(GetTripTickOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await context.TripTickOrders
            .Where(t => t.Id == request.Id)
            .Include(t => t.VehicleRegistrationCopyDocument)
            .Include(t => t.PersonalGovernmentalIdentityDocument)
            .Include(t => t.VehicleType)
            .Include(t => t.PassportDocument)
            // .ProjectTo<TripTickOrderDto>(mapper.ConfigurationProvider)
            .Select(t => t.MapToDto())
            .FirstOrDefaultAsync(cancellationToken);

        if (order == null)
        {
            throw new NotFoundException(nameof(TripTickOrder), request.Id.ToString());
        }

        return order;
    }
}
