namespace Product
{
    public class Product
    {
        private int _price;
        private string _name;

        public Product(int price, string name)
        {
            _price = price;
            _name = name;
        }

        public int GetPrice()
        {
            return _price;
        }

        public string GetName()
        {
            return _name;
        }
    }
}
