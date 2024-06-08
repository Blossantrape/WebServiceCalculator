using Microsoft.AspNetCore.Mvc;

namespace WebServiceCalculator;

[Route("api/calculator")]
[ApiController]
public class Calculator : ControllerBase
{
    [HttpGet("add")]
    public IActionResult Add(int a, int b)
    {
        return Ok(a + b);
    }
    [HttpGet("subtract")]
    public IActionResult Subtract(int a, int b)
    {
        return Ok(a - b);
    }
    [HttpGet("multiply")]
    public IActionResult Multiply(int a, int b)
    {
        return Ok(a * b);
    }
    [HttpGet("divide")]
    public IActionResult Divide(float a, float b)
    {
        if (b == 0)
        {
            return BadRequest("Cannot divide by zero");
        }
        return Ok(a / b);
    }
}