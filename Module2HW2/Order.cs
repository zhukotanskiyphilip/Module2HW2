namespace Order
{
    public class Order
    {
        private Cart.Cart _cart = new Cart.Cart();
        private int _total;
        private int _id;

        public Order(int id)
        {
            _id = id;
        }

        public void AddProduct(Product.Product product)
        {
            _cart.AddProduct(product);
            _total += product.GetPrice();
        }

        public void ClearCart()
        {
            _cart = new Cart.Cart();
        }

        public bool PlaceOrder()
        {
            Console.WriteLine("The following items have been added to your order:");
            foreach (var item in _cart.GetProducts())
            {
                Console.WriteLine($"{item.GetName()} - {item.GetPrice()} uah");
            }

            Console.WriteLine($"Total: {_total} uah");

            Console.WriteLine("Place an order? y/n");

            char answer;
            while (!char.TryParse(Console.ReadLine(), out answer) && answer != 'y' && answer != 'n')
            {
                Console.WriteLine("Wrong answer. Try again.");
            }

            if (answer == 'y')
            {
                Console.WriteLine("Your order has been processed.");
                Console.WriteLine($"Your order id is {_id}");
                return true;
            }

            Console.WriteLine("Your order has been cancelled.");
            return false;
        }
    }
}
