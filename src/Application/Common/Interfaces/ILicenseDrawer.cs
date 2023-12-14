using MacClientSystem.Application.Issuing.Command;

namespace MacClientSystem.Application.Common.Interfaces;

public interface ILicenseDrawer
{
    Task DrawLicenseCardAsync(DrawLicenseCommand request);
}
