using MacClientSystem.Application.Common.Interfaces;
using MacClientSystem.Application.Common.Mappings;
using MacClientSystem.Application.Issuing.Query.Models;
using MacClientSystem.Domain.Entities;

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

namespace MacClientSystem.Application.Issuing.Query;

public record GetExternalIssuedLicenseByOrderIdQuery(Guid LicenseOrderId) : IRequest<ExternalIssuedLicenseDto>;

public class GetIssuedLicenseByOrderIdQueryHandler
    (IApplicationDbContext context) : IRequestHandler<GetExternalIssuedLicenseByOrderIdQuery,
        ExternalIssuedLicenseDto>
{
    public async Task<ExternalIssuedLicenseDto> Handle(GetExternalIssuedLicenseByOrderIdQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await context.ExternalIssuedLicenses.Include(e => e.LicenseImagePath)
            .Where(r => r.LicenseOrderId == request.LicenseOrderId)
            .FirstOrDefaultAsync(cancellationToken);
        
        if (entity is null)
            throw new NotFoundException(nameof(ExternalIssuedLicense), request.LicenseOrderId.ToString());
        
        return entity.MapToDto();
    }
}
