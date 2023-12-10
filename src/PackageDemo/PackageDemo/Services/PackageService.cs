using Microsoft.EntityFrameworkCore;
using PackageDemo.Context;
using PackageDemo.Models;
using PackageDemo.Services.Interface;

namespace PackageDemo.Services;

public class PackageService(PackageContext packageContext) : IPackageService
{
    public async Task<PackageResponse?> GetByTrackingNumber(long trackingNumber)
    {
        var package = await packageContext
            .Packages
            .FirstOrDefaultAsync(x => x.TrackingNumber == trackingNumber);

        if (package == null)
            return null;

        return new PackageResponse(package);
    }

    public async Task<IEnumerable<long>> GetTrackingNumbers()
    {
        return await packageContext
            .Packages
            .Select(x => x.TrackingNumber)
            .ToListAsync();
    }
}
