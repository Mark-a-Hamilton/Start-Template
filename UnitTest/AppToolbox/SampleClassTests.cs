using System.Configuration;
using System.Runtime.ExceptionServices;

namespace UT.App;

public class SampleClassTests
{
    private readonly SampleClass _sut;

    public SampleClassTests()
    {
        _sut = new SampleClass(); // Create instance of Test 
    }

    [Fact]
    public void SampleMethod_String()
    {
        // Initailise - Arrange - Variables for tests
        int a = 1;

        // Call - Act - Method for test
        var result = _sut.SampleMethod(a);

        // Execute - Assert - Test results
       result.Should().ContainAny("OK!", "Failed");
       result.Should().NotBeNullOrEmpty();
    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(10, 12, 22)]
    [InlineData(7, 2, 9)]
    public void SampleMethod_Int(int a, int b, int expected)
    {
        // Initailise - Arrange - Variables for tests

        // Call - Act - Method for test
        var result = _sut.SampleMethod(a, b);

        // Execute - Assert - Test results}
        result.Should().Be(expected);
    }
}