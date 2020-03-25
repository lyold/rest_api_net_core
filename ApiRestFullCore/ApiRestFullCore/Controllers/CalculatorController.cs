using System;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestFullCore.Controllers
{
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        [HttpGet("Sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            try
            {
                if(isNumeric(firstNumber) && isNumeric(secondNumber))
                {
                    decimal first = Convert.ToDecimal(firstNumber);
                    decimal second = Convert.ToDecimal(secondNumber);

                    decimal sum = first + second;

                    return Ok(sum.ToString());
                }
                else
                {
                    return BadRequest("Invalid Operation.");
                }
            }
            catch(Exception e)
            {
                return BadRequest(string.Format("Error Unknow: {0}", e.Message));
            }
        }

        [HttpGet("Subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            try
            {
                if (isNumeric(firstNumber) && isNumeric(secondNumber))
                {
                    decimal first = Convert.ToDecimal(firstNumber);
                    decimal second = Convert.ToDecimal(secondNumber);

                    decimal difference = first - second;

                    return Ok(difference.ToString());
                }
                else
                {
                    return BadRequest("Invalid Operation.");
                }
            }
            catch (Exception e)
            {
                return BadRequest(string.Format("Error Unknow: {0}", e.Message));
            }
        }

        [HttpGet("Multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            try
            {
                if (isNumeric(firstNumber) && isNumeric(secondNumber))
                {
                    decimal first = Convert.ToDecimal(firstNumber);
                    decimal second = Convert.ToDecimal(secondNumber);

                    decimal multiplication = first * second;

                    return Ok(multiplication.ToString());
                }
                else
                {
                    return BadRequest("Invalid Operation.");
                }
            }
            catch (Exception e)
            {
                return BadRequest(string.Format("Error Unknow: {0}", e.Message));
            }
        }

        [HttpGet("Division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            try
            {
                if (isNumeric(firstNumber) && isNumeric(secondNumber) && !invalidDenominator(secondNumber))
                {
                    decimal first = Convert.ToDecimal(firstNumber);
                    decimal second = Convert.ToDecimal(secondNumber);

                    decimal division = first / second;

                    return Ok(division.ToString());
                }
                else
                {
                    return BadRequest("Invalid Operation.");
                }
            }
            catch (Exception e)
            {
                return BadRequest(string.Format("Error Unknow: {0}", e.Message));
            }
        }

        [HttpGet("Pow/{firstNumber}/{secondNumber}")]
        public IActionResult Pow(string firstNumber, string secondNumber)
        {
            try
            {
                if (isNumeric(firstNumber) && isNumeric(secondNumber))
                {
                    double first = Convert.ToDouble(firstNumber);
                    double second = Convert.ToDouble(secondNumber);

                    double pow = Math.Pow(first, second);

                    return Ok(pow.ToString());
                }
                else
                {
                    return BadRequest("Invalid Operation.");
                }
            }
            catch (Exception e)
            {
                return BadRequest(string.Format("Error Unknow: {0}", e.Message));
            }
        }

        private bool isNumeric(string number)
        {
            decimal convertedNumber;

            return decimal.TryParse(number, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out convertedNumber);
        }

        private bool invalidDenominator(string number)
        {
            decimal convertedNumber;
            decimal.TryParse(number, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out convertedNumber);

            if (convertedNumber == 0)
                return true;

            return false;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
