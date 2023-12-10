using PackageDemo.Context;
using PackageDemo.Services.Interface;

namespace PackageDemo.Services;

public class PackageValidationService : IPackageValidationService
{
    private const int MAX_WEIGHT_IN_G = 20000;
    private const int MAX_LENGTH_IN_CM = 60;
    private const int MAX_HEIGHT_IN_CM = 60;
    private const int MAX_WIDTH_IN_CM = 60;

    public bool HasValidSize(Package package)
    {
        if (package is null)
            return false;

        if (package.Weight is <= 0 or > MAX_WEIGHT_IN_G)
            return false;

        if (package.Length is <= 0 or > MAX_LENGTH_IN_CM)
            return false;

        if (package.Height is <= 0 or > MAX_HEIGHT_IN_CM)
            return false;

        if (package.Width is <= 0 or > MAX_WIDTH_IN_CM)
            return false;

        return true;
    }
}
