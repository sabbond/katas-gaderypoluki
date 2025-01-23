namespace gaderypoluki.Test;
using FluentAssertions;

[TestClass]
public class gaderypolukiTest
{
    public static IEnumerable<object[]> TestData
    {
        get
        {
            return
            [
                [
                    String.Empty,
                    String.Empty,
                    "emptystring"
                ],
                [
                    "ZXC",
                    "ZXC",
                    "no encoded characters"
                ],
                [
                    "that's cool",
                    "thgt's cppu",
                    "lower case characters"
                ],
                [
                    "GRAND HOTEL",
                    "AYGNE HPTDU",
                    "upper case characters"
                ],
                [
                    "GADeryPolUKi",
                    "AGEdyrOpuLIk",
                    "all the changed chars, mixed case"
                ],
                [
                    "GADery𐐷PolUKi",
                    "AGEdyr𐐷OpuLIk",
                    "all the changed chars, mixed case, one two-char rune in the middle"
                ],
                [
                    "ABCD",
                    "GBCE",
                    "test 1 from web",
                ],
                [
                    "Ala has a cat",
                    "Gug hgs g cgt",
                    "test 2 from web",
                ],
                [
                    "gaderypoluki",
                    "agedyropulik",
                    "test 3 from web",
                ],
                [
                    "Gug hgs g cgt",
                    "Ala has a cat",
                    "test 4 from web",
                ],
                [
                    "agedyropulik",
                    "gaderypoluki",
                    "test 5 from web",
                ],
                [
                    "GBCE",
                    "ABCD",
                    "test 6 from web",
                ]
            ];
        }
    }

    public static IEnumerable<object[]> Test2Data
    {
        get
        {
            return
            [
                [
                    "ABCD",
                    "agedyropulik",
                    "GBCE",
                    "test 1 from web 2"
                ],
                [
                    "Ala has a cat",
                    "gaderypoluki",
                    "Gug hgs g cgt",
                    "test 2 from web 2"
                ],
                [
                    "Dkucr pu yhr ykbir",
                    "politykarenu",
                    "Dance on the table",
                    "test 3 from web 2"
                ],
                [
                    "Hmdr nge brres",
                    "regulaminowy",
                    "Hide our beers",
                    "test 4 from web 2"
                ],
                [
                    "I epn'𐐷 wgn𐐷 𐐷p 𐐷guk gbpl𐐷 i𐐷",
                    "agedyropult𐐷",
                    "I don't want to talk about it",
                    "Map to a 2 char rune"
                ],
                [
                    "Hmdr ng𐐷 brr𐐷s",
                    "𐐷rgulaminowy",
                    "Hid𐐷 our b𐐷𐐷rs",
                    "Map from a 2 char rune"
                ]
            ];
        }
    }


    [TestMethod]
    [DynamicData(nameof(TestData))]
    public void Gaderypoluki_EncodeReturnsExpectedResults(string input, string expected, string scenario)
    {
        Gaderypoluki.Encode(input).Should().BeEquivalentTo(expected, scenario);
    }

    [TestMethod]
    [DynamicData(nameof(TestData))]
    public void Gaderypoluki_DecodeReturnsExpectedResults(string input, string expected, string scenario)
    {
        Gaderypoluki.Decode(input).Should().BeEquivalentTo(expected, scenario);
    }

    [TestMethod]
    [DynamicData(nameof(TestData))]
    public void Gaderypoluki2_EncodeReturnsExpectedResults(string input, string expected, string scenario)
    {
        Gaderypoluki2.Encode(input, "gaderypoluki").Should().BeEquivalentTo(expected, scenario);
    }

    [TestMethod]
    [DynamicData(nameof(Test2Data))]
    public void Gaderypoluki2_EncodeReturnsExpectedResultsWithDifferentKeys(string input, string key, string expected, string scenario){
        Gaderypoluki2.Encode(input, key).Should().BeEquivalentTo(expected, scenario);
    }
}
