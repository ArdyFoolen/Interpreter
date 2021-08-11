using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpreterExample
{
    public class ProductFinder
    {
        public IProductRepository Repository { get; private set; }
        public ProductFinder(IProductRepository repository)
        {
            this.Repository = repository;
        }

        public List<Product> By(Spec spec)
            => SelectBy(spec);

        private List<Product> SelectBy(Spec spec)
        {
            List<Product> foundProducts = new List<Product>();
            foreach (Product product in Repository)
            {
                if (spec.IsSatisfiedBy(product))
                    foundProducts.Add(product);
            }
            return foundProducts;
        }
    }
}
