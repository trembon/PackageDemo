using PackageDemo.Context;

namespace PackageDemo.Services.Interface;

public interface IPackageValidationService
{
    /// <summary>
    /// Validates if a package is within the weight and size limits.
    /// * Weight max 20kg
    /// * Length max 60cm
    /// * Height max 60cm
    /// * Width max 60cm
    /// </summary>
    /// <param name="package"></param>
    /// <returns></returns>
    bool HasValidSize(Package package);
}
