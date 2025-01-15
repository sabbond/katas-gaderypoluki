using System.Collections.Generic;
using System.Text;

namespace gaderypoluki;

public static class Gaderypoluki2
{
    // second gaderypoluki from codewars
    // strictly speaking, it's not rigourously specced and there are only
    // a limited number of keys specified so......
    // I could just extend the switch statement version.  it'd be quick to run.
    // however, it's clear the intent is the key can be any string
    // (though if it's an odd number of characters I'm not clear what is supposed to happen...)
    // anyhow, I'm gonna assume key can only consist of single character runes
    // and throw if it's an odd length
    // and as before, logically encode and decode do the same thing so there's no separate implementation

    public static string Encode(string message, string key)
    {
        if (message == null || key == null || key.Length % 2 == 1) throw new ArgumentException("null params or possibly odd length key");
        Dictionary<char, char> lookups = LookupsFromKey(key);
        var inChars = message.ToCharArray();
        char[] outChars = new char[inChars.Length];
        for (int count = 0; count < inChars.Length; count++)
        {
            if (lookups.ContainsKey(inChars[count]))
            {
                outChars[count] = lookups[inChars[count]];
            }
            else
            {
                outChars[count] = inChars[count];
            }
        }
        return new string(outChars);
    }

    public static string Decode(string input, string key){
        return Encode(input, key);
    }

    private static Dictionary<Char, Char> LookupsFromKey(string key)
    {
        var lookups = new Dictionary<Char, Char>();
        var lowKeyChars = key.ToLowerInvariant().ToCharArray();
        var highKeyChars = key.ToUpperInvariant().ToCharArray();
        for (int count = 0; count < lowKeyChars.Length - 1; count += 2)
        {
            lookups.Add(lowKeyChars[count], lowKeyChars[count + 1]);
            lookups.Add(lowKeyChars[count + 1], lowKeyChars[count]);
            lookups.Add(highKeyChars[count], highKeyChars[count + 1]);
            lookups.Add(highKeyChars[count + 1], highKeyChars[count]);
        }
        return lookups;
    }
}