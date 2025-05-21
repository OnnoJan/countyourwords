using System.Collections;

namespace CountYourWords.Tests.Common;

public class StringArrayEqualityComparer : EqualityComparer<string[]>
{
    public override bool Equals(string[]? x, string[]? y)
    {
        switch (x)
        {
            case null when y is not null:
                return false;
            case not null when y is null:
                return false;
            case null when y is null:
                return true;
        }

        if (x.Length != y.Length) return false;

        for (int i = 0; i < x.Length; i++)
            if (x[i] != y[i])
                return false;

        return true;
    }

    public override int GetHashCode(string[] obj)
    {
        Hashtable hashtable = new();
        foreach (string item in obj) hashtable.Add(item, item);
        return hashtable.GetHashCode();
    }
}
