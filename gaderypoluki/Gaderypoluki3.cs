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
        // invalid input could give us more than one mapping per character
        // validate keys before return
        var key = String.Concat(keys.OrderBy(key => key));
        // if any letter appears more than once then the key is invalid
        if (key.GroupBy(c => c).Any(g => g.Count() > 1)) {
            throw new ArgumentException("Inconsistent mappings in data, key invalid");
        }
        return key;
    }
}
