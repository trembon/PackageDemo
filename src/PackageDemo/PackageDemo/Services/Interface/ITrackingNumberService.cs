namespace PackageDemo.Services.Interface;

public interface ITrackingNumberService
{
    /// <summary>
    /// Tries to parse a tracking number with the defined rules.
    /// * Exactly 18 characters long
    /// * Only numbers
    /// * Should start with the defined "company code"
    /// </summary>
    /// <param name="input"></param>
    /// <param name="trackingNumber"></param>
    /// <returns></returns>
    bool TryParse(string input, out long trackingNumber);

    /// <summary>
    /// Generates a new tracking number.
    /// </summary>
    /// <returns></returns>
    long GenerateNew();
}
