using PackageDemo.Models;

namespace PackageDemo.Services.Interface;

public interface IPackageService
{
    /// <summary>
    /// Get the tracking numbers of all the registrered packages.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<string>> GetTrackingNumbers();

    /// <summary>
    /// Get a package by the tracking number.
    /// </summary>
    /// <param name="trackingNumber"></param>
    /// <returns></returns>
    Task<PackageResponse?> GetByTrackingNumber(long trackingNumber);

    /// <summary>
    /// Save a package to the database.
    /// </summary>
    /// <param name="package"></param>
    /// <returns>The package tracking number.</returns>
    Task<PackageResponse?> CreatePackage(CreatePackageRequest package);
}
