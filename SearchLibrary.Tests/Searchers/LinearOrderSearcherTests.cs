using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchLibrary.Models;
using SearchLibrary.Searchers;

namespace SearchLibrary.Tests.Searchers
{
    public class LinearOrderSearcherTests
    {
        private static Order[] Orders() => new[]
        {
            new Order { Id = 10, CustomerName = "A", TotalAmount = 100 },
            new Order { Id = 20, CustomerName = "B", TotalAmount = 200 },
            new Order { Id = 30, CustomerName = "C", TotalAmount = 300 },
            new Order { Id = 40, CustomerName = "D", TotalAmount = 400 },
            new Order { Id = 50, CustomerName = "E", TotalAmount = 500 }
        };

        [Fact]
        public void FindsExistingOrder()
        {
            var s = new LinearOrderSearcher();
            int idx = s.SearchById(40, Orders());
            Assert.Equal(3, idx);
        }

        [Fact]
        public void ReturnsMinus1_WhenNotFound()
        {
            var s = new LinearOrderSearcher();
            int idx = s.SearchById(999, Orders());
            Assert.Equal(-1, idx);
        }

        [Fact]
        public void EmptyArray_ReturnsMinus1()
        {
            var s = new LinearOrderSearcher();
            int idx = s.SearchById(10, System.Array.Empty<Order>());
            Assert.Equal(-1, idx);
        }
    }
}
