namespace Lab4Web.Services.Linq
{
    public interface ILinqService
    {
        int Test1(int value);

        public IEnumerable<SupermarketProduct> Test2();

        public IEnumerable<string> Test3();//string category)
        public int Test4();

        public IEnumerable<string> Test5(char letter);

        public IEnumerable<(string ProductName, decimal Price, int StockQuant, string CategoryName)> Test6();

        public IEnumerable<(string Category, int ProductCount)> Test7();


    }
}
