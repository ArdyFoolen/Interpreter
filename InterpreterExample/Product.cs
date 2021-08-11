using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpreterExample
{
    public enum ProductSize
    {
        NotApplicable,
        Small,
        Medium,
        Large
    }

    public class Product
    {
        public string Id { get; private set; }
        public string Description { get; private set; }
        public Color Color { get; private set; }
        public Price Price { get; private set; }
        public ProductSize Size { get; private set; }
        
        public Product(string id, string description, Color color, Price price, ProductSize size)
        {
            this.Id = id;
            this.Description = description;
            this.Color = color;
            this.Price = price;
            this.Size = size;
        }
    }
}
