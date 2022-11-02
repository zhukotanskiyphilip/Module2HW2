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

                                    var result = htmlDoc.DocumentNode.SelectNodes(".//rz-grid[@class=\"ng-star-inserted\"]//" +
                                       "rz-catalog-tile[@class=\"ng-star-inserted\"]");

                                    Product.Product[] products = new Product.Product[result.Count];

                                    if (result != null && result.Count > 0)
                                    {
                                        for (int i = 0; i < products.Length; i++)
                                        {
                                            var priceNode = result[i].SelectSingleNode(".//p[class=\"ng-star-inserted\"]");
                                            var price = string.Empty;
                                            if (priceNode != null)
                                            {
                                                price = priceNode.InnerText;
                                            }

                                            var nameNode = result[i].SelectSingleNode(".//a[class=\"goods - tile__heading ng - star - inserted\"]");
                                            var name = string.Empty;
                                            if (nameNode != null)
                                            {
                                                name = nameNode.InnerText;
                                            }

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
