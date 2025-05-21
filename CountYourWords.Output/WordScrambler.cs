namespace CountYourWords.Output;

public class WordScrambler : IWordScrambler
{
    public string Encode(string word)
    {
        string reversed = Reverse(word);
        Span<char> charArray = reversed.ToCharArray();
        return new string(charArray);
    }

    private string Reverse(string input)
    {
        Span<char> charSpan = input.ToCharArray();

        int left = 0;
        int right = charSpan.Length - 1;
        while (left < right)
        {
            char temp = charSpan[left];
            charSpan[left] = charSpan[right];
            charSpan[right] = temp;
            left++;
            right--;
        }

        for (int i = 0; i < charSpan.Length; i++) charSpan[i] = ToUpperIfEven(charSpan[i], i + 1);

        return new string(charSpan);
    }

    private char ToUpperIfEven(char c, int position) => position % 2 == 0 ? char.ToUpper(c) : c;
}
