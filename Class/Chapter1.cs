using System.Collections.Generic;

namespace Chapter1
{
    public class Product
    {
        public readonly string name;
        public string Name
        {
            get { return name; }
        }

        public readonly decimal? price;
        public decimal? Price
        {
            get { return price; }
        }

        public Product(string name, decimal price)
        {
            this.name = name;
            this.price = price;
        }

        public static List<Product> GetSampleProducts()
        {
            List<Product> list = new List<Product>();
            list.Add(new Product("West Side Story", 9.99m));
            list.Add(new Product("Assassins", 14.99m));
            list.Add(new Product("Frogs", 13.99m));
            list.Add(new Product("Sweeney Todd", 10.99m));
            return list;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Name, Price);
        }
    }
}