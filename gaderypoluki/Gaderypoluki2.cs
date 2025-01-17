using System.Collections.Generic;
using System.Text;

namespace gaderypoluki;

public static class Gaderypoluki2
{
    // second gaderypoluki from codewars
    // https://www.codewars.com/kata/592b7b16281da94068000107
    //
    // use runes instead of chars for full unicode supportd
    public static string Encode(string message, string key)
    {
        if (message == null || key == null || key.EnumerateRunes().Count() % 2 == 1) throw new ArgumentException("null params or possibly odd length key");
        Dictionary<Rune, Rune> lookups = LookupsFromKey(key);
        var inRunes = message.EnumerateRunes().ToArray();
        Rune[] outRunes = new Rune[inRunes.Length];
        for (int count = 0; count < inRunes.Length; count++)
        {
            if (lookups.ContainsKey(inRunes[count]))
            {
                outRunes[count] = lookups[inRunes[count]];
            }
            else
            {
                outRunes[count] = inRunes[count];
            }
        }
        return string.Concat(outRunes.Select(rune => rune.ToString()));
    }

    public static string Decode(string input, string key){
        return Encode(input, key);
    }

    private static Dictionary<Rune, Rune> LookupsFromKey(string key)
    {
        var lookups = new Dictionary<Rune, Rune>();
        var lowKeyRunes = key.ToLowerInvariant().EnumerateRunes().ToArray();
        var highKeyRunes = key.ToUpperInvariant().EnumerateRunes().ToArray();
        for (int count = 0; count < lowKeyRunes.Length - 1; count += 2)
        {
            lookups.Add(lowKeyRunes[count], lowKeyRunes[count + 1]);
            lookups.Add(lowKeyRunes[count + 1], lowKeyRunes[count]);
            lookups.Add(highKeyRunes[count], highKeyRunes[count + 1]);
            lookups.Add(highKeyRunes[count + 1], highKeyRunes[count]);
        }
        return lookups;
    }
}