namespace gaderypoluki;

public static class Gaderypoluki3
{
    public static string FindKey(string[] messages, string[] secrets)
    {
        // use a hashset so each key is only stored once
        var keys = new HashSet<String>();
        var allMessages = string.Concat(messages).ToLowerInvariant().ToCharArray();
        var allSecrets = string.Concat(secrets).ToLowerInvariant().ToCharArray();
        if (allMessages.Length != allSecrets.Length)
        {
            throw new ArgumentException("Messages and Secrets should be the same length");
        }
        for (int count = 0; count < allMessages.Length; count++)
        {
            var messageChar = allMessages[count];
            var secretChar = allSecrets[count];
            if (messageChar != secretChar)
            {
                // char has been encoded, add both values to the keys
                // order them alphabetically
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
        // concatenate keys to give us the key
        var key = String.Concat(keys.OrderBy(key => key));
        // invalid input could give us more than one mapping per character
        if (key.GroupBy(c => c).Any(g => g.Count() > 1)) {
            throw new ArgumentException("Inconsistent mappings in data, key invalid");
        }
        return key;
    }
}
