using Lab4Web.Services.Delegate;
using Microsoft.AspNetCore.Mvc;

namespace Lab4Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestDelegateController : ControllerBase
    {
        private readonly IDelegateService _delegateService;

        public TestDelegateController(IDelegateService delegateService)
        {
            _delegateService = delegateService;
        }

        [HttpGet("test-1")]
        public string Test1(string name)
        {
            var callback = _delegateService.Hello;

            return _delegateService.Introduction(name, callback);
        }

        [HttpGet("test-2")]
        public string Test2(string name, bool welcome)
        {
            var callback1 = _delegateService.Hello;
            var callback2 = (string firstname, string lastname) => $"Bye, {firstname} {lastname}";

            var callback = welcome ? callback1 : callback2;

            return _delegateService.Introduction(name, callback);
        }

        [HttpGet("ex1-(a)")] // test pt 1.a)
        public string Test3(string value)
        {   //expresie lambda
            Func<string, string> callback=str=>
            {
                char[] stringulMeu = str.ToCharArray();
                Array.Reverse(stringulMeu);
                return new string(stringulMeu);
            };
            return _delegateService.StringInverse(value, callback);
        }

        [HttpGet("ex1-(b)")] //test pt 1.b)
        public string Test4(string value)
        {
            
            int n = value.Split(' ').Length;
            //folosim metodele ca si parametri
            var callback1 = _delegateService.OneWord;
            var callback2 = _delegateService.MoreWords;

            //se decide daca nr de cuvinte=1 sau mai mare
            var callback = n == 1 ? callback1 : callback2;

            return callback(value);
         
        }


        [HttpGet("ex1-(c)")] //test pt 1.c)
        public string Test5(double n1, double n2)
        {
            return _delegateService.ConsecutiveOp(n1, n2);
        }


    }
}
