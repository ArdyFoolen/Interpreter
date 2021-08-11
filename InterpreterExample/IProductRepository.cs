using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpreterExample
{
    public interface IProductRepository : IEnumerable<Product>, IEnumerator<Product>
    {
    }
}
