using MacClientSystem.Application.Common.Interfaces;
using MacClientSystem.Application.Issuing.Query.Models;
using MacClientSystem.Domain.Entities;

namespace MacClientSystem.Application.Issuing.Query;

public class GetUserExternalIssuedLicensesQuery: IRequest<ExternalIssuedLicenseVm>
{
    public Guid UserId { get; set; }
}

public class GetUserIssuedLicensesQueryHandler(IApplicationDbContext context) : IRequestHandler<GetUserExternalIssuedLicensesQuery, ExternalIssuedLicenseVm>
{
    public async Task<ExternalIssuedLicenseVm> Handle(GetUserExternalIssuedLicensesQuery request, CancellationToken cancellationToken)
    {
        var licenses = await context.ExternalIssuedLicenses
            .Where(r => r.UserId == request.UserId.ToString())
            .Include(e => e.LicenseImagePath)
            .Select(e=>e.MapToDto())
            .ToListAsync(cancellationToken);

        if (licenses is null)
            throw new NotFoundException(nameof(ExternalIssuedLicense), request.UserId.ToString());

        var vm = new ExternalIssuedLicenseVm { List = licenses, RecordsCount = licenses.Count, };
        
        return vm;
    }
}
