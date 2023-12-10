using Microsoft.EntityFrameworkCore;
using PackageDemo.Context;
using PackageDemo.Models;
using PackageDemo.Services.Interface;

namespace PackageDemo.Services;

public class PackageService(PackageContext packageContext, ITrackingNumberService trackingNumberService, IPackageValidationService packageValidationService) : IPackageService
{
    public async Task<PackageResponse?> CreatePackage(CreatePackageRequest package)
    {
        var trackingNumber = trackingNumberService.GenerateNew();

        var createdPackage = new Package
        {
            TrackingNumber = trackingNumber,
            Weight = package.Weight,
            Length = package.Length,
            Height = package.Height,
            Width = package.Width
        };

        packageContext.Packages.Add(createdPackage);
        await packageContext.SaveChangesAsync();

        return await GetByTrackingNumber(trackingNumber);
    }

    public async Task<PackageResponse?> GetByTrackingNumber(long trackingNumber)
    {
        var package = await packageContext
            .Packages
            .FirstOrDefaultAsync(x => x.TrackingNumber == trackingNumber);

        if (package == null)
            return null;

        bool hasValidSize = packageValidationService.HasValidSize(package);
        return new PackageResponse(package, hasValidSize);
    }

    public async Task<IEnumerable<string>> GetTrackingNumbers()
    {
        return await packageContext
            .Packages
            .Select(x => x.TrackingNumber.ToString())
            .ToListAsync();
    }
}
