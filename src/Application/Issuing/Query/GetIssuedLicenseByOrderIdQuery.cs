using MacClientSystem.Application.Common.Interfaces;
using MacClientSystem.Application.Issuing.Query.Models;

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

namespace MacClientSystem.Application.Issuing.Query;

public class GetIssuedLicenseByOrderIdQuery: IRequest<IssuedLicenseDto>
{
    public Guid OrderId { get; set; }
}


public class GetIssuedLicenseByOrderIdQueryHandler(/*IApplicationDbContext context, IMapper mapper*/) : IRequestHandler<GetIssuedLicenseByOrderIdQuery, IssuedLicenseDto>
{
    public async /*async*/ Task<IssuedLicenseDto> Handle(GetIssuedLicenseByOrderIdQuery request, CancellationToken cancellationToken)
    {
        // var entity = await context.IssuedLicenses
        //     .FindAsync(request.OrderId);
        //
        // if (entity == null)
        // {
        //     throw new NotFoundException(nameof(IssuedLicense), request.OrderId);
        // }
        //
        // return mapper.Map<IssuedLicenseDto>(entity);
        // return "localhost:5001/uploads/ELicense/final1.png";
        
        throw new NotImplementedException();
    }
}
