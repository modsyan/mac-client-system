using MacClientSystem.Application.Common.Interfaces;
using MacClientSystem.Application.LicenseOrders.Command.CreateLicenseOrder;
using MacClientSystem.Domain.Entities;
using MacClientSystem.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace MacClientSystem.Application.LicenseOrders.Command.CreateLicenseOrder;

public class CreateLicenseOrderCommand: IRequest<bool>
{
     public string FullName { get; set; } = string.Empty!;
     public DateTime BirthDate { get; set; }
     public BloodTypes BloodType { get; set; }
     public int NationalityId { get; set; }
     public int SourceOfLocalLicenseId { get; set; }
     public Gander Gander { get; set; }
     public string PassportId { get; set; } = String.Empty!;
     public int LicenseTypeId { get; set; }
     public int LicenseDuration { get; set; }
     public int PersonalPhotoFileId { get; set; }
     public IFormFile PersonalPhoto { get; set; } = default!;
     public IFormFile LocalDrivingLicense { get; set; } = default!;
     public IFormFile Passport { get; set; } = default!;
}

public class CreateLicenseOrderCommandHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<CreateLicenseOrderCommand, bool>
{
    public async Task<bool> Handle(CreateLicenseOrderCommand request, CancellationToken cancellationToken)
     {
          var entity = mapper.Map<LicenseOrder>(request);
          await context.LicenseOrders.AddAsync(entity, cancellationToken);
          return await context.SaveChangesAsync(cancellationToken) > 0;
     }
}
