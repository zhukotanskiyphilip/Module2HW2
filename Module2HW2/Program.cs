// Реалізувати покупку в інтернет магазині.
// Критерії:
// Отримати масив якихось товарів - check(GetProducts.cs)
// Вибрати з масиву декілька товарів для покупки (до 10 шт) і додати в корзину покупок - check(Program.cs)
// Корзина покупок зберігає товари, поки замовлення не сформоване - check(Cart.cs)
// Оформити замовлення товарів - check(Order.cs)
// Після оформлення необхідно повідомити покупця про те, що було сформовано замовлення з певним номером - check(Order.cs)

namespace Program
{
    public class Program
    {
        public static void Main()
        {
            // Here we get an assortment
            Product.Product[] products = GetProducts.GetProducts.GetParsed("https://rozetka.com.ua/sadoviy-decor/c4625415/tip-75231=326505/");

            // Here we save orders
            Order.Order[] orders = new Order.Order[100];

            // Here we generate order id
            int orderId = 0;
            char answer = '0';

            do
            {
                Console.WriteLine("Do you want to buy something? y/n");
                char.TryParse(Console.ReadLine(), out answer);

                while (answer != 'y' && answer != 'n')
                {
                    Console.WriteLine("Wrong answer. Try again.");
                    char.TryParse(Console.ReadLine(), out answer);
                }

                if (answer == 'y')
                {
                    Order.Order order = new Order.Order(orderId);

                    Random random = new Random();
                    for (int i = 0; i < 10; i++)
                    {
                        order.AddProduct(products[random.Next(0, products.Length)]);
                    }

                    if (order.PlaceOrder())
                    {
                        orders[orderId] = order;
                        orderId++;
                    }
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            while (answer == 'y');
        }
    }
}