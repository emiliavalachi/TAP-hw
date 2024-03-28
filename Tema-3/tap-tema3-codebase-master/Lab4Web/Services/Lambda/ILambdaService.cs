namespace Lab4Web.Services.Lambda
{
    public interface ILambdaService
    {
        Tuple<int, int, int> Test1(int value);

        bool Test2(string value);

        Task<string> Test3Async(string value);

        public string Test4();

        public int Test5(char c);

        public string Test6(int n1, int n2);

        public string Test7(int n1, int n2);

        public string Test8(int n1, int n2);

        public int Test9((int red, int white, int yellow) roses);

        Task<int> Test10(int value);


    }
}
