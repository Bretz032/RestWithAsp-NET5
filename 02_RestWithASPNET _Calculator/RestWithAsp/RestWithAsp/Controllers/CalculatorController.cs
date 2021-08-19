using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RestWithAsp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
      

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }


        //Soma
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber)&& IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        //Subtracao
        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult Sub(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(sub.ToString());
            }
            return BadRequest("Invalid Input");
        }

        //Divisao
        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult Div(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(div.ToString());
            }
            return BadRequest("Invalid Input");
        }

        //Multiplicacao
        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public IActionResult Mult(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var mult = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(mult.ToString());
            }
            return BadRequest("Invalid Input");
        }

        //RaizQuadrada
        [HttpGet("sqr/{number}/")]
        public IActionResult Sqr(string number)
        {

            if (IsNumeric(number) )
            {
                var sqr = Math.Sqrt(ConvertToDecimal( number)) ;
                return Ok(sqr.ToString());
            }
            return BadRequest("Invalid Input");
        }
        //Demais Metodos
        private double ConvertToDecimal(string Number)
        {
            return Double.Parse(Number);
        }

        private bool IsNumeric(string Number)
        {

           if(Regex.IsMatch(Number, @"^\d+$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
