using PackageDemo.Context;

namespace PackageDemo.Models;

public class PackageResponse(Package package, bool isValid)
{
    public long TrackingNumber { get; } = package.TrackingNumber;

    public int Weight { get; } = package.Weight;

    public double Length { get; } = package.Length;

    public double Height { get; } = package.Height;

    public double Width { get; } = package.Width;

    public bool IsValid { get; } = isValid;
}
