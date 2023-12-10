namespace PackageDemo.Context;

public class Package
{
    /// <summary>
    /// Auto-Generated ID for the package
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Tracking Number
    /// </summary>
    public long TrackingNumber { get; set; }

    /// <summary>
    /// Weight of the package in gram (g)
    /// </summary>
    public int Weight { get; set; }

    /// <summary>
    /// Length of the package in centimeter (cm)
    /// </summary>
    public double Length { get; set; }

    /// <summary>
    /// Height of the package in centimeter (cm)
    /// </summary>
    public double Height { get; set; }

    /// <summary>
    /// Width of the package in centimeter (cm)
    /// </summary>
    public double Width { get; set; }
}
