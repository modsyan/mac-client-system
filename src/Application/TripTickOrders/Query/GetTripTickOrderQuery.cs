using MacClientSystem.Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection.TripTickOrders.Query;

namespace MacClientSystem.Application.TripTickOrders.Query;

public record GetTripTickOrderQuery(int Id) : IRequest<TripTickOrderDto>;

public class GetTripTickOrderQueryHandler : IRequestHandler<GetTripTickOrderQuery, TripTickOrderDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTripTickOrderQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TripTickOrderDto> Handle(GetTripTickOrderQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.TripTickOrders
            .FindAsync(request.Id);

        return _mapper.Map<TripTickOrderDto>(entity);
    }
}
