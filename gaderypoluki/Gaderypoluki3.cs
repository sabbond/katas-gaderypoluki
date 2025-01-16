namespace gaderypoluki;

public static class Gaderypoluki3
{
    public static string FindKey(string[] messages, string[] secrets)
    {
        var keys = new HashSet<String>();
        var bigMessage = string.Concat(messages).ToLowerInvariant().ToCharArray();
        var bigSecret = string.Concat(secrets).ToLowerInvariant().ToCharArray();
        if (bigMessage.Length != bigSecret.Length)
        {
            throw new ArgumentException("Messages and Secrets should be the same length");
        }
        for (int count = 0; count < bigMessage.Length; count++)
        {
            var messageChar = bigMessage[count];
            var secretChar = bigSecret[count];
            if (messageChar != secretChar)
            {
                // char has been encoded, add before and after to the keys
                // but order them alphabetically
                // (sorting probs inefficient with 2 values, use if)
                if (messageChar < secretChar)
                {
                    keys.Add(string.Concat(messageChar, secretChar));
                }
                else
                {
                    keys.Add(string.Concat(secretChar, messageChar));
                }
            }
        }
        // if no lookups found short circuit and return empty string
        // means we can expect .First to work and not throw
        if (keys.Count == 0) return String.Empty;
        // invalid input could give us more than one mapping per character
        // should validate keys before returning it
        var prevLookup = string.Empty;
        foreach (var key in keys)
        {
            if (key[..1] == prevLookup)
            {
                throw new ArgumentException($"inconsistent data, multiple mappings for {prevLookup}");
            }
            prevLookup = key[..1];
        }
        // ok, data is consistent, emit the keys in alpha order
        return String.Concat(keys.OrderBy(key => key));
    }
}
