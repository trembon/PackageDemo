using PackageDemo.Services.Interface;

namespace PackageDemo.Services;

public class TrackingNumberService : ITrackingNumberService
{
    private const int TRACKING_NUMBER_LENGTH = 18;
    private const string COMPANY_CODE = "999";

    public long GenerateNew()
    {
        throw new NotImplementedException();
    }

    public bool TryParse(string input, out long trackingNumber)
    {
        trackingNumber = -1;

        // check so we have a value
        if (string.IsNullOrWhiteSpace(input))
            return false;

        // check the length of the tracking number
        if (input.Length != TRACKING_NUMBER_LENGTH)
            return false;

        // check so the tracking number has the correct "company code"
        if (!input.StartsWith(COMPANY_CODE))
            return false;

        // check so its only numbers
        if (!long.TryParse(input, out trackingNumber))
            return false;

        return true;
    }
}
