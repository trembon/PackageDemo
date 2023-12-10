using PackageDemo.Models;

namespace PackageDemo.Services.Interface;

public interface IPackageService
{
    Task<IEnumerable<long>> GetTrackingNumbers();

    Task<PackageResponse?> GetByTrackingNumber(long trackingNumber);
}
