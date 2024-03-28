namespace Lab4Web.Services.Delegate
{
    public interface IDelegateService
    {
        string Introduction(string value, Func<string, string, string> callback);

        string Hello(string firstname, string lastname);

        public string StringInverse(string value, Func<string, string> callback);

        public string OneWord(string text);

        public string MoreWords(string text);

        public delegate void ArithmeticOp(double n1, double n2);

        public string Addition(double n1, double n2);

        public string Subtraction(double n1, double n2);

        public string Multiplication(double n1, double n2);

        public string Division(double n1, double n2);

        public string ConsecutiveOp(double n1, double n2);




    }

}
