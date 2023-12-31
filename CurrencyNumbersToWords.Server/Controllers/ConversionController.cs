﻿using CurrencyNumbersToWords.Server.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyNumbersToWords.Server.Controllers
{
    /// <summary>
    /// API controller to validate the input string and convert its value to its equivalent word representation.
    /// </summary>
    /// <param name="request">The conversion request object.</param>
    /// <returns>The words representation of the input string in dollars.</returns>
    [ApiController]
    [Route("api/[controller]")]
    public class ConversionController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] ConversionRequest request)
        {
            // Remove spaces.
            string inputString = request.Text.Replace(" ", "");

            // Check if the input is empty or null.
            if (string.IsNullOrEmpty(inputString))
            {
                return BadRequest("The input cannot be empty or null.");
            }

            // Check if the input uses the correct separator.
            if (inputString.Contains('.'))
            {
                return BadRequest("Please enter a ',' (comma) as the decimal separator.");
            }

            // Check if the input is a valid decimal number.
            if (!decimal.TryParse(inputString, out decimal value))
            {
                return BadRequest("Only digits, spaces, and ',' (comma) are valid entries. Use ',' as a decimal separator.");
            }

            // Check if the whole number is within the valid range ($0-999 999 999,99).
            string[] dollarParts = [];
            try
            {
                dollarParts = inputString.Split(',');

                if (dollarParts[0].Length > 9 || value < 0)
                {
                    return UnprocessableEntity("Please enter a number between $0-999 999 999,99.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }

            // Check if the input contains more than one decimal separator.
            char charToCount = ',';
            int count = inputString.Count(c => c == charToCount);
            if (count > 1)
            {
                return BadRequest("Please enter only a single ',' (comma) as the decimal separator.");
            }

            // Check that the maximum number of cents is 99, if true, store the whole and fractional parts in two integer variables.
            int dollars = 0;
            int cents = 0;
            try
            {
                if (dollarParts.Length > 1)
                {
                    if (dollarParts[1].Length > 2)
                    {
                        return UnprocessableEntity($"Maximum fractional resolution is 99.");
                    }
                    else if (dollarParts[1].Length == 2)
                    {
                        dollars = int.Parse(dollarParts[0]);
                        cents = int.Parse(dollarParts[1]);
                    }
                    else
                    {
                        dollars = int.Parse(dollarParts[0]);
                        cents = int.Parse(dollarParts[1]);
                        cents *= 10;
                    }
                }
                else
                {
                    dollars = int.Parse(dollarParts[0]);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }

            // Convert the input amount into equivalent words and return the response to the client.
            return Ok(Data.Services.Convert.ConvertToWords(dollars, cents));
        }
    }
}
