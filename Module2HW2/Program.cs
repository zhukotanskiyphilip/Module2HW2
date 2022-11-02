namespace Program
{
    public class Program
    {
        public static void Main()
        {
            Product.Product[] products = GetProducts.GetProducts.GetParsed("https://rozetka.com.ua/sadoviy-decor/c4625415/tip-75231=326505/");

            for (int i = 0; i < products.Length; i++)
            {
                Console.WriteLine($"Name of product {i} is {products[i].GetName()}");
                Console.WriteLine($"Price of product {i} is {products[i].GetPrice()}");
            }
        }
    }
}