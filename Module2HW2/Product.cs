namespace Product
{
    public class Product
    {
        private string _price;
        private string _name;

        public Product(string price, string name)
        {
            _price = price;
            _name = name;
        }

        public string GetPrice()
        {
            return _price;
        }

        public string GetName()
        {
            return _name;
        }
    }
}
