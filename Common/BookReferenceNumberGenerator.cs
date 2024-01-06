namespace BookStore.Common;

public static class BookReferenceNumberGenerator
{
    private static readonly object lockObject = new();
    private static int counter = 1;

    public static string GenerateBookReferenceNumber()
    {
        lock (lockObject)
        {
            int currentCounterValue = counter++;
            return $"BK-{DateTime.Now:yyyyMMddHHmmss}-{currentCounterValue:D4}";
        }
    }
}