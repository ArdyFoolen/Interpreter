using InterpreterExample;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpreterTests
{
    public class ProductRepositoryTest : IProductRepository
    {
        private List<Product> products = new List<Product>();
        private int index = -1;

        public Product Current => products[index];
        object IEnumerator.Current => this.Current;
        public bool hasNext { get => index < products.Count - 1; }

        public bool MoveNext()
        {
            if (hasNext)
            {
                index++;
                return true;
            }
            return false;
        }

        public void Reset()
            => index = -1;

        public void Add(Product product)
            => products.Add(product);

        public IEnumerator<Product> GetEnumerator()
        {
            Reset();
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        public void Dispose() { }

        public Product FireTruck { get; private set; } =
            new Product("f1234", "Fire Truck",
                Color.Red, 8.95f, ProductSize.Medium);

        public Product BarbieClassic { get; private set; } =
            new Product("b7654", "Barbie Classic",
                Color.Yellow, 15.95f, ProductSize.Small);

        public Product Frisbee { get; private set; } =
           new Product("f4321", "Frisbee",
              Color.Pink, 9.99f, ProductSize.Large);

        public Product Baseball { get; private set; } =
           new Product("b2343", "Baseball",
              Color.White, 8.95f, ProductSize.NotApplicable);

        public Product ToyConvertible { get; private set; } =
           new Product("p1112", "Toy Porsche Convertible",
              Color.Red, 230.00f, ProductSize.NotApplicable);

        public void FillRepository()
        {
            products.Add(FireTruck);
            products.Add(BarbieClassic);
            products.Add(Frisbee);
            products.Add(Baseball);
            products.Add(ToyConvertible);
        }
    }
}
