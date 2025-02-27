using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace RandomNumbersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomController : ControllerBase
    {
        private readonly Random _random = new Random();

        
        [HttpGet("number")]
        public IActionResult GetRandomNumber()
        {
            int randomNumber = _random.Next(); 
            return Ok(randomNumber);
        }

        
        [HttpGet("number/range")]
        public IActionResult GetRandomNumberInRange([FromQuery] int min, [FromQuery] int max)
        {
            if (min >= max)
            {
                return BadRequest("El valor de 'min' debe ser menor que 'max'.");
            }

            int randomNumber = _random.Next(min, max + 1); 
            return Ok(randomNumber);
        }

        
        [HttpGet("decimal")]
        public IActionResult GetRandomDecimal()
        {
            double randomDecimal = _random.NextDouble(); 
            return Ok(randomDecimal);
        }

        
        [HttpGet("string")]
        public IActionResult GetRandomString([FromQuery] int length)
        {
            if (length <= 0)
            {
                return BadRequest("La longitud debe ser mayor que 0.");
            }

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] randomString = new char[length];

            for (int i = 0; i < length; i++)
            {
                randomString[i] = chars[_random.Next(chars.Length)];
            }

            return Ok(new string(randomString));
        }
    }
}