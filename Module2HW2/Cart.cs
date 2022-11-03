namespace Cart
{
    public class Cart
    {
        private Product.Product[] _products = new Product.Product[10];
        private int _iterator = 0;

        public void AddProduct(Product.Product product)
        {
            _products[_iterator] = product;
            _iterator++;
        }

        public Product.Product[] GetProducts()
        {
            return _products;
        }
    }
}
