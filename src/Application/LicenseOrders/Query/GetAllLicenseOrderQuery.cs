using MacClientSystem.Application.Common.Interfaces;
using MacClientSystem.Application.Common.Models;
using MacClientSystem.Domain.Entities;

namespace MacClientSystem.Application.LicenseOrders.Query;

public record GetAllLicenseOrderQuery : IRequest<LicenseOrderVm>;

public class GetAllLicenseOrderQueryHandler 
    (IApplicationDbContext context/*, IMapper mapper*/) : IRequestHandler<GetAllLicenseOrderQuery, LicenseOrderVm>
{
    public async Task<LicenseOrderVm> Handle(GetAllLicenseOrderQuery request, CancellationToken cancellationToken)
    {
        var order = await context.LicenseOrders
            .Where(o => o.AccountId == 1) //Account 1 for Firebase Account TODO: Remove this
            .Include(l=> l.PassportImage)
            .Include(l=>l.PersonalPhoto)
            .Include(l=>l.LocalDrivingLicense)
            // .ProjectTo<LicenseOrderDto>(mapper.ConfigurationProvider)
            .Select(t=>t.MapToDto())
            .ToListAsync(cancellationToken);

        return new LicenseOrderVm { LicenseOrders = order };
    }
}
