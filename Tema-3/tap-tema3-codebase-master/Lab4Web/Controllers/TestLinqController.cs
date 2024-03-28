using Lab4Web.Services.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Lab4Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestLinqController : ControllerBase
    {
        private readonly ILinqService _linqService;

        public TestLinqController(ILinqService linqService)
        {
            _linqService = linqService;
        }

        [HttpGet("test-1")]
        public int Get(int age)
        {
            return _linqService.Test1(age);
        }


        [HttpGet("ex3-(c)-(i)")]
        public IEnumerable<SupermarketProduct> Test2()
        {
            return _linqService.Test2();
        }

        [HttpGet("ex3-(c)-(ii)")]
        public IEnumerable<string> GetProductNames()//string category)
        {
            return _linqService.Test3();//category);
        }

        [HttpGet("ex3-(c)-(iii)")]
        public int Test4()
        {
            return _linqService.Test4();
        }

        [HttpGet("ex3-(d)-(i)")]
        public IEnumerable<string> Test5(char letter)
        {
            return _linqService.Test5(letter);
        }

        [HttpGet("ex3-(d)-(ii)")]
        public IEnumerable<(string ProductName, decimal Price, int StockQuant, string CategoryName)> Test6()
        {
            return _linqService.Test6();
        }

        [HttpGet("ex3-(d)-(iii)")]

        public IEnumerable<(string Category, int ProductCount)> Test7()
        {
            return _linqService.Test7();
        }
    }
}
