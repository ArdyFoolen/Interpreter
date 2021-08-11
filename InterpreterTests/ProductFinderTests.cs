using NUnit.Framework;
using InterpreterExample;
using System.Drawing;
using System.Collections.Generic;

namespace InterpreterTests
{
    public class ProductFinderTests
    {
        private ProductFinder finder;
        private ProductRepositoryTest repository;

        private void createProductRepository()
        {
            repository = new ProductRepositoryTest();
            repository.FillRepository();
        }

        [SetUp]
        public void Setup()
        {
            createProductRepository();
            finder = new ProductFinder(repository);
        }

        [Test]
        public void TestFindByCompositeColors()
        {
            List<Spec> specs = new List<Spec>();
            specs.Add(Color.Red.ToSpec());
            specs.Add(Color.White.ToSpec());
            List<Product> foundProducts = finder.By(new CompositeOrSpec(specs));
            Assert.AreEqual(3, foundProducts.Count);
            Assert.IsTrue(foundProducts.Contains(repository.FireTruck));
            Assert.IsTrue(foundProducts.Contains(repository.Baseball));
            Assert.IsTrue(foundProducts.Contains(repository.ToyConvertible));
        }

        [Test]
        public void TestFindByCompositeColorSizeAndBelowPrice()
        {
            float price = 10.0f;
            List<Spec> specs = new List<Spec>();
            specs.Add(Color.Red.ToSpec());
            specs.Add(ProductSize.Small.ToSpec());
            specs.Add(((Price)price).Below());

            List<Product> foundProducts = finder.By(new CompositeAndSpec(specs));
            Assert.AreEqual(0, foundProducts.Count);

            specs = new List<Spec>();
            specs.Add(Color.Red.ToSpec());
            specs.Add(ProductSize.Medium.ToSpec());
            specs.Add(((Price)price).Below());

            foundProducts = finder.By(new CompositeAndSpec(specs));
            Assert.AreEqual(1, foundProducts.Count);
            Assert.IsTrue(foundProducts.Contains(repository.FireTruck));
        }

        [Test]
        public void TestFindByColor()
        {
            List<Product> foundProducts = finder.By(Color.Red.ToSpec());
            Assert.AreEqual(2, foundProducts.Count);
            Assert.IsTrue(foundProducts.Contains(repository.FireTruck));
            Assert.IsTrue(foundProducts.Contains(repository.ToyConvertible));
        }

        [Test]
        public void TestFindByPrice()
        {
            Price price = 8.95f;
            List<Product> foundProducts = finder.By(price.ToSpec());
            Assert.AreEqual(2, foundProducts.Count);
            foreach (Product product in foundProducts)
                Assert.IsTrue(product.Price == price);
        }

        [Test]
        public void TestFindBySize()
        {
            var size = ProductSize.NotApplicable;
            List<Product> foundProducts = finder.By(size.ToSpec());
            Assert.AreEqual(2, foundProducts.Count);
            foreach (Product product in foundProducts)
                Assert.IsTrue(product.Size == size);
        }

        [Test]
        public void TestFindByColorSizeAndBelowPrice()
        {
            Price price = 10.0f;

            Spec spec = Color.Red.And(ProductSize.Small.ToSpec()).And(price.Below());
            List<Product> foundProducts = finder.By(spec);
            Assert.AreEqual(0, foundProducts.Count);

            spec = Color.Red.And(ProductSize.Medium.ToSpec()).And(price.Below());
            foundProducts = finder.By(spec);
            Assert.AreEqual(1, foundProducts.Count);
            Assert.IsTrue(foundProducts.Contains(repository.FireTruck));
        }

        [Test]
        public void TestFindBelowPriceAvoidingAColor()
        {
            Price price = 9.0f;

            Spec spec = Color.White.Not().And(price.Below());
            List<Product> foundProducts = finder.By(spec);
            Assert.AreEqual(1, foundProducts.Count);
            Assert.IsTrue(foundProducts.Contains(repository.FireTruck));

            spec = Color.Red.Not().And(price.Below());
            foundProducts = finder.By(spec);
            Assert.AreEqual(1, foundProducts.Count);
            Assert.IsTrue(foundProducts.Contains(repository.Baseball));
        }

        [Test]
        public void TestFindBy2ColorsSizeAndBelowPrice()
        {
            Price price = 10.0f;

            Spec spec = Color.White.Or(Color.Red.ToSpec()).And(ProductSize.Small.ToSpec()).And(price.Below());
            List<Product> foundProducts = finder.By(spec);
            Assert.AreEqual(0, foundProducts.Count);

            spec = Color.White.Or(Color.Red.ToSpec()).And(ProductSize.NotApplicable.ToSpec()).And(price.Below());
            foundProducts = finder.By(spec);

            Assert.AreEqual(1, foundProducts.Count);
            Assert.IsTrue(foundProducts.Contains(repository.Baseball));
        }
    }
}