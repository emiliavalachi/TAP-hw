using Microsoft.AspNetCore.Http.HttpResults;
using System.Text;

namespace Lab4Web.Services.Delegate
{
    public class DelegateService : IDelegateService
    {
        public string Introduction(string value, Func<string, string, string> callback)
        {
            var upperName = value.ToUpper();
            return callback(upperName, "Test");
        }

        public string Hello(string firstname, string lastname)
        {
            return $"Hello, {firstname} {lastname}";
        }



        //////////////
        //1. a) Delegate pentru a insera apelarea unei metode într-o alta metoda
        //meotda pt inversarea unui sir de caractere introdus:
        public string StringInverse(string value, Func<string, string> callback)
        {

            return callback(value);
        }



        /////////////
        //1. b) 2 metode Delegate pt a demonstra execuția unei dintre ele în funcție de o condiție impusă
        //metode pentru cazurile in care un string este format dintr un cuvant/mai multe:
        public string OneWord(string text)
        {
            return $"'{text}' reprezinta un singur cuvant.";
        }

        public string MoreWords(string text)
        {
            string[] words = text.Split(' ');
            int n = words.Length;

            //se concateneaza cuvintele
            string text2 = string.Join("", words);
            return $"'{text}' este format din {n} cuvinte.\n\n Acum '{text2}' este un singur cuvant, ha! ;)";

        }



        /////////////
        //1. c) Delegate pentru a apela mai multe metode consecutive la finalul unei metode
        // voi face un chain cu metodele pt operatii aritmetice cu 2 numere

            public delegate string ArithmeticOp(double n1, double n2);

            public string Addition(double n1, double n2)
            {
                return $"{n1} + {n2} = {n1 + n2}";
            }

            public string Subtraction(double n1, double n2)
            {
                return $"{n1} - {n2} = {n1 - n2}";
            }

            public string Multiplication(double n1, double n2)
            {
                return $"{n1} * {n2} = {n1 * n2}";
            }

            public string Division(double n1, double n2)
            {
                if (n2 != 0)
                {
                    return $"{n1} / {n2} = {n1 / n2}";
                }
                else
                {
                    return "Nu putem imparti la 0!";
                }
            }

        //chain ul
        public string ConsecutiveOp(double n1, double n2)
        {
            //asignam toate metodele pe rand
            ArithmeticOp delegateChain = Addition;
            delegateChain += Subtraction;
            delegateChain += Multiplication;
            delegateChain += Division;

            //formalitati, poate cam haotice, pentru ca sa pot converti in string???
            StringBuilder res = new StringBuilder();

            foreach (ArithmeticOp operation in delegateChain.GetInvocationList())
            {
                res.AppendLine(operation(n1, n2));
            }

            return res.ToString();
        }

    }
}





