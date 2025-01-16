namespace gaderypoluki.Test;
using FluentAssertions;

[TestClass]
public class gaderypoluki3Test
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
                ]
            ];
        }
    }

    [TestMethod]
    [DynamicData(nameof(TestData))]
    public void Gaderypoluki3_GeneratesCorrectKeyForInput(string[] messages, string[] secrets, string expected){
        Gaderypoluki3.FindKey(messages, secrets).Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void Gaderypoluki3_throwsWhenInputsLengthDoesntMatch(){
        Action action = () => Gaderypoluki3.FindKey(new[] {"123456"}, new[] {"123"});
        action.Should().Throw<ArgumentException>();
    }

    [TestMethod]
    public void Gaderypoluki3_throwsWhenInputEncodingWrong(){
        Action action = () => Gaderypoluki3.FindKey(new[] {"hide my beers"}, new[] {"hked mr bdlys"});
        action.Should().Throw<ArgumentException>();
    }
}