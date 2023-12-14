using MacClientSystem.Application.Issuing.Query.Models;

namespace MacClientSystem.Application.Issuing.Query;

public class GetUserIssuedLicensesQuery: IRequest<IssuedLicenseVm>
{
    public Guid UserId { get; set; }
}

public class GetUserIssuedLicensesQueryHandler : IRequestHandler<GetUserIssuedLicensesQuery, IssuedLicenseVm>
{
    public Task<IssuedLicenseVm> Handle(GetUserIssuedLicensesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
