namespace Lab4Web.Services.Lambda
{
    public class LambdaService : ILambdaService
    {
        public Tuple<int, int, int> Test1(int value)
        {
            var lambdaExp = (int num) => new Tuple<int, int, int>(num % 10, (num /= 10) % 10, (num /= 10) % 10);
            return lambdaExp(value);
        }

        public bool Test2(string value)
        {
            return int.TryParse(value, out _);
        }

        public async Task<string> Test3Async(string value)
        {
            var lambaExp = async (string v) =>
            {
                await Delay();
                return value.ToLower();
            };

            return await lambaExp(value);
        }


        public Task Delay()
        {
            return Task.Delay(10000);
        }



        //2.a) O expresie Lambda pentru fiecare tip:
        //(i) fără parametri
        public string Test4()
        {
            Random r = new Random();
            int randNr = r.Next();

            Func<int> nextNr = () => randNr+1;

            return $"Numarul ales random: {randNr}\nSuccesorul sau: {nextNr()}";
        }


        //(ii) cu 1 parametru
        //o metoda care returneaza valoarea ASCII pt un caracter dat
        public int Test5(char c)
        {
            Func<char, int> Convert = c => (int)c;
            return Convert(c);
        }

        //(iii) cu 2 parametri
        //o metoda care lipeste 2 numere (ca si concatenarea la stringuri)
        //si apoi calculeaza suma cifrelor noului numar
        public string Test6(int n1, int n2)
        {
            //statement block
            Func<int, int, string> stSum = (n1, n2) =>
            {
                string sticked = $"{n1}{n2}";
                int sum = 0;
                foreach (char c in sticked)
                
                        sum += int.Parse(c.ToString());
       
                return $"La lipirea {n1} cu {n2} am obtinut nr-ul: {sticked}\n" +
                $"Suma cifrelor sale: {sum}";
            };

            return stSum(n1, n2);
        }


        //(iv) cu parametri neutilizati în expresie
        public string Test7(int n1, int n2)
        {
            Func<int, int, string> value = (_, _) => " nimic nu se va intampla!";
            return $"{n1} si {n2}\nRezultat:{value(n1, n2)}";
        }


        //(v) cu parametri default
        //impartirea la 0
        public string Test8(int n1, int n2)
        {   
            Func<int, int, string> value = (int n1, int n2 = 0) => "nu putem efectua imparitrea la 0!";
            return $"{n1} / {n2} = {value(n1, n2)}";
        }

        //(vi) cu tuple ca parametru
        //florariile au trandafiri rosii, albi si galbeni, se returneaza nr de trandafiri
        public int Test9((int red, int white, int yellow) roses)
        {
            Func<(int, int, int), int> total = r =>
            {
                return r.Item1 + r.Item2 + r.Item3;
            };

            return total(roses);
        }

        //2.b)
        //expresie Lambda într-un context asynchronous
        //se calculeaza dublul parametrului dupa 3 secunde
        public async Task<int> Test10(int value)
        {
            Func<int, Task<int>> asyncLambda = async (int v) =>
            {
                await Task.Delay(3000);

                return v * 2;
            };
            return await asyncLambda(value);
        }

    }
}
