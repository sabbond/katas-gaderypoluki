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
                ]
            ];
        }
    }    

    [TestMethod]
    [DynamicData(nameof(TestData))]
    public void Gaderypoluki_EncodeReturnsExpectedResults(string input, string expected, string scenario){
        Gaderypoluki.Encode(input).Should().BeEquivalentTo(expected, scenario);
    }
}
