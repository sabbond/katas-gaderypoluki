namespace gaderypoluki;

public static class Gaderypoluki
{
    // this class is gonna treat chars like they are runes
    // nothing in gederypoluki is anywhere near the codepoints that require 32 bits
    // so those chars should be left alone
    // (check that in the tests, eh?  𐐷 is a 32bit utf-16 character.)
    public static string Encode(string input) {
        var inChars = input.ToCharArray();
        char[] outChars = new char[inChars.Length];
        for(int Count = 0; Count < inChars.Length; Count++){
            outChars[Count] = EncodeChar(inChars[Count]);
        }
        return new String(outChars);
    }

    public static string Decode(string input){
        // there is no difference, just swap the pairs again!
        return Encode(input);
    }

    private static Char EncodeChar(char input) {
        switch (input){
            case 'g': return 'a';
            case 'a': return 'g';
            case 'd': return 'e';
            case 'e': return 'd';
            case 'r': return 'y';
            case 'y': return 'r';
            case 'p': return 'o';
            case 'o': return 'p';
            case 'l': return 'u';
            case 'u': return 'l';
            case 'k': return 'i';
            case 'i': return 'k';
            case 'G': return 'A';
            case 'A': return 'G';
            case 'D': return 'E';
            case 'E': return 'D';
            case 'R': return 'Y';
            case 'Y': return 'R';
            case 'P': return 'O';
            case 'O': return 'P';
            case 'L': return 'U';
            case 'U': return 'L';
            case 'K': return 'I';
            case 'I': return 'K';
            default: return input;
        }
    }
}
