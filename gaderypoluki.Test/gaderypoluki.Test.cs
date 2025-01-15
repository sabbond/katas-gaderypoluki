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

    [TestMethod]
    [DynamicData(nameof(TestData))]
    public void Gaderypoluki_EncodeReturnsExpectedResults(string input, string expected, string scenario){
        Gaderypoluki.Encode(input).Should().BeEquivalentTo(expected, scenario);
    }

    [TestMethod]
    [DynamicData(nameof(TestData))]
    public void Gaderypoluki_DecodeReturnsExpectedResults(string input, string expected, string scenario){
        Gaderypoluki.Decode(input).Should().BeEquivalentTo(expected, scenario);
    }
}
