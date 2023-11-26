using MacClientSystem.Application.Common.Interfaces;
using MacClientSystem.Domain.Entities;

namespace MacClientSystem.Application.LicenseOrders.Query;

public record GetLicenseOrderByIdQuery(int Id) : IRequest<LicenseOrderDto>;

public class GetLicenseOrderQueryHandler
    (IApplicationDbContext context/*, IMapper mapper*/) : IRequestHandler<GetLicenseOrderByIdQuery, LicenseOrderDto>
{
    public async Task<LicenseOrderDto> Handle(GetLicenseOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await context.LicenseOrders
            .Where(o => o.Id == request.Id)
            .Include(l=> l.PassportImage)
            .Include(l=>l.PersonalPhoto)
            .Include(l=>l.LocalDrivingLicense)
            // .ProjectTo<LicenseOrderDto>(mapper.ConfigurationProvider)
            .Select(t=>t.MapToDto())
            .SingleOrDefaultAsync(cancellationToken);

        if (order == null)
        {
            throw new NotFoundException(nameof(LicenseOrder), request.Id.ToString());
        }

        return order;
    }
}
