namespace CountYourWords.Tests.Common;

public static class StringArrayExtensions
{
    public static bool Equal(this string[] x, string[] y)
    {
        StringArrayEqualityComparer comparer = new();
        return comparer.Equals(x, y);
    }
}
