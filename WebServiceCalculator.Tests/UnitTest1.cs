using Microsoft.AspNetCore.Mvc;

namespace WebServiceCalculator.Tests;

public class WebServiceCalculatorTests
{
    private readonly Calculator _calculator;
    
    public WebServiceCalculatorTests()
    {
        _calculator = new Calculator();
    }
    
    [Fact]
    public void Add_ReturnsCorrectResult()
    {
        var result = _calculator.Add(1, 2) as OkObjectResult;
        Assert.NotNull(result);
        Assert.Equal(3, result.Value);
    }
    
    [Fact]
    public void Subtract_ReturnsCorrectResult()
    {
        var result = _calculator.Subtract(3, 2) as OkObjectResult;
        Assert.NotNull(result);
        Assert.Equal(1, result.Value);
    }
    
    [Fact]
    public void Multiply_ReturnsCorrectResult()
    {
        var result = _calculator.Multiply(4, 2) as OkObjectResult;
        Assert.NotNull(result);
        Assert.Equal(8, result.Value);
    }
    
    [Fact]
    public void Divide_ReturnsCorrectResult()
    {
        var result = _calculator.Divide(20, 5) as OkObjectResult;
        Assert.NotNull(result);
        Assert.Equal(4, result.Value);
    }
    
    [Fact]
    public void DivideByZero_ReturnsBadRequest()
    {
        var result = _calculator.Divide(15, 0) as BadRequestObjectResult;
        Assert.NotNull(result);
    }
}