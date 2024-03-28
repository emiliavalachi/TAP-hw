using Lab4Web.Services.Lambda;
using Microsoft.AspNetCore.Mvc;

namespace Lab4Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestLambdaController : ControllerBase
    {
        private readonly ILambdaService _lambdaService;

        public TestLambdaController(ILambdaService lambdaService)
        {
            _lambdaService = lambdaService;
        }

        [HttpGet("test-1")]
        public string Get(int value)
        {
            var tupleValue = _lambdaService.Test1(value);
            return $"{tupleValue.Item1} / {tupleValue.Item2} / {tupleValue.Item3}";
        }

        [HttpGet("test-2")]
        public string Test2(string value)
        {
            return _lambdaService.Test2(value) ? "Number" : "Not number";
        }

        [HttpGet("test-3")]
        public string Test3(string value)
        {
            var result = _lambdaService.Test3Async(value).Result;
            return result;
        }

        //////////////////////////////////////

        [HttpGet("ex2-(a)-(i)")]
        public string Test4()
        {
            return _lambdaService.Test4();
        }

        [HttpGet("ex2-(a)-(ii)")]
        public string Test5(char c)
        {
            int asciiValue = _lambdaService.Test5(c);
            return $"Valoarea ASCII a lui '{c}': {asciiValue}";
        }

        [HttpGet("ex2-(a)-(iii)")]
        public string Test6(int n1, int n2)
        {
            return _lambdaService.Test6(n1, n2);
        }


        [HttpGet("ex2-(a)-(iv)")]
        public string Test7(int n1, int n2)
        {
            return _lambdaService.Test7(n1, n2);
        }

        [HttpGet("ex2-(a)-(v)")]
        public string Test8(int n1, int n2=0)
        {
            return _lambdaService.Test8(n1, n2);
        }

        [HttpGet("ex2-(a)-(vi)")]
        public int Test9(int redCount, int whiteCount, int yellowCount)
        {
            var Roses = (redCount, whiteCount, yellowCount);
            return _lambdaService.Test9(Roses);
        }

        [HttpGet("ex2-(b)")]
        public async Task<int> TestAsync(int value)
        {
            return await _lambdaService.Test10(value);
        }


    }
}
