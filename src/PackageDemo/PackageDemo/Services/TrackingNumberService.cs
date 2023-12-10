using PackageDemo.Services.Interface;

namespace PackageDemo.Services;

public class TrackingNumberService : ITrackingNumberService
{
    private const int TRACKING_NUMBER_LENGTH = 18;
    private const string COMPANY_CODE = "999";

    public long GenerateNew()
    {
        int length = TRACKING_NUMBER_LENGTH - COMPANY_CODE.Length;
        var minMaxValues = MaxIntWithXDigits(length);

        Random random = new(DateTime.UtcNow.Millisecond);
        long identifier = random.NextInt64(minMaxValues.min, minMaxValues.max);

        string trackingNumber = COMPANY_CODE + identifier.ToString();
        return long.Parse(trackingNumber);
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

    private static (long min, long max) MaxIntWithXDigits(int x)
    {
        if (x <= 0 || x > 18)
            throw new ArgumentOutOfRangeException(nameof(x));

        long min = (long)Math.Pow(10, x - 1);

        return (min == 1 ? 0 : min, min * 10 - 1);
    }
}
