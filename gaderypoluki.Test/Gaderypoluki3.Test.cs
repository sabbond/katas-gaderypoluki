namespace gaderypoluki.Test;
using FluentAssertions;

[TestClass]
public class Gaderypoluki3Test
{
    public static IEnumerable<Object[]> TestData
    {
        get
        {
            return
            [
                [
                    new string[] {"dance on the table", "hide my beers", "scouts rocks"},
                    new string[] {"egncd pn thd tgbud" ,"hked mr bddys" , "scplts ypcis"},
                    "agdeikluopry"
                ],
                [
                    new string[] {"dance on the table", "hide my beers", "scouts rocks"},
                    new string[] {"dkucr pu yhr ykbir", "hldr mt brres", "scpnys epcas"},
                    "akerilnuopty"
                ],
                [
                    new string[] {"THE QUICK BROWN FOX jumps over the LAZY BOY"},
                    new string[] {"UHC QTNEO BYKWI FKX jtaps kvcy uhc LMZR BKR"},
                    "amceinkorytu"
                ]
            ];
        }
    }

    [TestMethod]
    [DynamicData(nameof(TestData))]
    public void Gaderypoluki3_GeneratesCorrectKeyForInput(string[] messages, string[] secrets, string expected)
    {
        Gaderypoluki3.FindKey(messages, secrets).Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void Gaderypoluki3_throwsWhenInputsLengthDoesntMatch()
    {
        Action action = () => Gaderypoluki3.FindKey(["123456"], ["123"]);
        action.Should().Throw<ArgumentException>();
    }

    [TestMethod]
    public void Gaderypoluki3_throwsWhenInputEncodingInconsistent()
    {
        Action action = () => Gaderypoluki3.FindKey(["hide my beers"], ["hked mr bdlys"]);
        action.Should().Throw<ArgumentException>();
    }
}