namespace GetProducts
{
    public static class GetProducts
    {
        public static Product.Product[] GetParsed(string url)
        {
            try
            {
                using (HttpClientHandler handler = new HttpClientHandler())
                {
                    using (var client = new HttpClient(handler))
                    {
                        using (var response = client.GetAsync(url).Result)
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                var html = response.Content.ReadAsStringAsync().Result;
                                if (!string.IsNullOrEmpty(html))
                                {
                                    HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
                                    htmlDoc.LoadHtml(html);

                                    var result = htmlDoc.DocumentNode.SelectNodes(".//div[@class=\"goods-tile__inner\"]");

                                    Product.Product[] products = new Product.Product[result.Count];

                                    if (result != null && result.Count > 0)
                                    {
                                        for (int i = 0; i < products.Length; i++)
                                        {
                                            var nameNode = result[i].SelectSingleNode(".//a[@class=\"goods-tile__heading ng-star-inserted\"]" +
                                                "//span[@class=\"goods-tile__title\"]");
                                            var name = string.Empty;
                                            if (nameNode != null)
                                            {
                                                name = nameNode.InnerText;
                                            }

                                            var priceNode = result[i].SelectSingleNode(".//div[@class=\"goods-tile__prices\"]" +
                                                "//span[@class=\"goods-tile__price-value\"]");
                                            var sPrice = string.Empty;
                                            if (priceNode != null)
                                            {
                                                sPrice = priceNode.InnerText;

                                                var temp = string.Empty;
                                                foreach (var c in sPrice)
                                                {
                                                    if (char.IsDigit(c))
                                                    {
                                                        temp += c;
                                                    }
                                                }

                                                sPrice = temp;
                                            }

                                            var price = 0;
                                            int.TryParse(sPrice, out price);

                                            Product.Product product = new Product.Product(price, name);
                                            products[i] = product;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("No products in collection");
                                    }

                                    return products;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }
    }
}
