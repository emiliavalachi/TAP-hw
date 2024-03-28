namespace Lab4Web.Services.Linq
{
    public class Student
    {
        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }

    //////////3.a) O clasa care sa contina mai multe(cel puțin 5) proprietăți
    public class SupermarketProduct
    {
        public SupermarketProduct(string name, string category, decimal price, int stockQuant)
        {
            //Id = id;
            Name = name;
            Category = category;
            Price = price;
            StockQuant= stockQuant;
        } 

        public Guid Id { get; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int StockQuant { get; set; }

    }

    //3.b)
    // o clasa statică care pastreaza o lista de măcar 10 obiecte

    public static class Inventory
    {
        private static List<SupermarketProduct> products = new List<SupermarketProduct>();
        static Inventory()
        {
            products.Add(new SupermarketProduct("Lapte", "Lactate", 9, 50));
            products.Add(new SupermarketProduct("Paine", "Panificatie", 7, 100));
            products.Add(new SupermarketProduct("Unt", "Lactate", 19, 40));
            products.Add(new SupermarketProduct("Mere", "Fructe", 4.5m, 80));
            products.Add(new SupermarketProduct("Piept de pui", "Carne", 30, 30));
            products.Add(new SupermarketProduct("Paste", "Panificatie", 12, 60));
            products.Add(new SupermarketProduct("Capsuni", "Fructe", 17, 20));
            products.Add(new SupermarketProduct("Suc de mere", "Bauturi", 14, 16));
            products.Add(new SupermarketProduct("Iaurt", "Lactate", 3, 60));
            products.Add(new SupermarketProduct("Cereale", "Panificatie", 18, 55));
        }

        public static List<SupermarketProduct> Products
        {
            get { return products; }
        }

        public static void AddProduct(SupermarketProduct product)
        {
            products.Add(product);
        }

        //public static void RemoveProduct(int productId)
        //{
        //    var productToRemove = products.Find(p => p.Id == productId);
        //    if (productToRemove != null)
        //    {
        //        products.Remove(productToRemove);
        //    }
        //    else
        //    {
        //        Console.WriteLine($"Product with ID {productId} not found in inventory.");
        //    }
        //}
    }


    public class LinqService : ILinqService
    {
        public List<Student> stUdents = new List<Student>()
        {
            new Student("T1", 25),
            new Student("T2", 29),
            new Student("T3", 33),
        };
       
        public int Test1(int value)
        {
            //Query-expression
            //var query = from student in stUdents
            //            where student.Age >= value
            //                select student;

            //return query.Count();

            //Method-expression 
            return stUdents.Count(student => student.Age >= value);
        }




//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        //3.c) (i)
        //query care returnează o lista de obiecte(de tipul de mai sus) după aplicarea unei clauze where
        //pt produsele cu pret mai mare de 20
        public IEnumerable<SupermarketProduct>  Test2()
        {
            var query = from product in Inventory.Products
                        where product.Price > 20
                        select product;

            return query;
        }

        //3.c) (ii)
        //returnează o lista de stringuri, doar cu valoarea unei proprietăți
        //proprietatea aleasa va fi categoria produsului din supermarket
        public IEnumerable<string> Test3()//string category)
        {
            var query = from product in Inventory.Products
                        where product.Category == "Lactate"//category
                        select product.Name;

            return query;
        }


        //3.c) (iii)
        //query care returnează numărul de elemente din lista primită
        public int Test4()
        {
            //method based
            return Inventory.Products.Count();
        }

        //3.d) (i)
        //query cu WHERE
        //selectez produsele dupa prima litera

        public IEnumerable<string> Test5(char letter)
        {
            var query = from product in Inventory.Products
                        where product.Name.StartsWith(letter.ToString(), System.StringComparison.OrdinalIgnoreCase)
                        select product.Name;

            return query;
        }

        //3.d) (ii)
        //query cu JOIN
        //adaug un produse noi
        public IEnumerable<(string ProductName, decimal Price, int StockQuant, string CategoryName)> Test6()
        {
            //o noua lista din care o sa luam produse si o sa le adaugam in Inventory
            var List2 = new List<SupermarketProduct>
            {
                 new SupermarketProduct("Croissant", "Panificatie", 5, 30),
            };

            var query = from product in List2
                        join category in Inventory.Products on product.Category equals category.Category
                        select new
                        {
                            ProductName = product.Name,
                            Price = product.Price,
                            StockQuant = product.StockQuant,
                            CategoryName = product.Category
                        };

            return query.Select(p => (p.ProductName, p.Price, p.StockQuant, p.CategoryName));


        }


        // 3.d) (iii)
        // cu GROUP
        public IEnumerable<(string Category, int ProductCount)> Test7()
        {
            var query = from product in Inventory.Products
                        group product by product.Category into groupedProducts
                        select new
                        {
                            Category = groupedProducts.Key,
                            ProductCount = groupedProducts.Count()
                        };

            return query.Select(gp => (gp.Category, gp.ProductCount));
        }

    }
}
