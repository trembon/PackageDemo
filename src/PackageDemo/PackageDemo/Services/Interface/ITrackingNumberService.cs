namespace PackageDemo.Services.Interface;

public interface ITrackingNumberService
{
    bool TryParse(string input, out long trackingNumber);

    long GenerateNew();
}
