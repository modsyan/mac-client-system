using MacClientSystem.Application.Common.Interfaces;

namespace MacClientSystem.Application.LicenseOrders.Query;

public record GetUserLicenseOrderQuery(string ExternalUserId) : IRequest<LicenseOrderVm>;

public class GetUserLicenseOrderQueryHandler(IApplicationDbContext context/*, IMapper mapper*/) : IRequestHandler<GetUserLicenseOrderQuery, LicenseOrderVm>
{
    public async Task<LicenseOrderVm> Handle(GetUserLicenseOrderQuery request, CancellationToken cancellationToken)
    {
        var order = await context.LicenseOrders
            .Where(x => x.ExternalUserId == request.ExternalUserId)
            .Include(l=> l.PassportImage)
            .Include(l=>l.PersonalPhoto)
            .Include(l=>l.LocalDrivingLicense)
            // .ProjectTo<LicenseOrderDto>(mapper.ConfigurationProvider)
            .Select(x => x.MapToDto())
            .ToListAsync(cancellationToken);

        return new LicenseOrderVm
        {
            LicenseOrders = order
        };
    }
}
