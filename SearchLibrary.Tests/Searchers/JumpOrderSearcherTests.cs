using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchLibrary.Models;
using SearchLibrary.Searchers;

namespace SearchLibrary.Tests.Searchers
{
    public class JumpOrderSearcherTests
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
        public void FindsFirstElement()
        {
            var s = new JumpOrderSearcher();
            int idx = s.SearchById(10, Orders());
            Assert.Equal(0, idx);
        }

        [Fact]
        public void FindsLastElement()
        {
            var s = new JumpOrderSearcher();
            int idx = s.SearchById(50, Orders());
            Assert.Equal(4, idx);
        }

        [Fact]
        public void ReturnsMinus1_WhenNotFound()
        {
            var s = new JumpOrderSearcher();
            int idx = s.SearchById(35, Orders());
            Assert.Equal(-1, idx);
        }

        [Fact]
        public void EmptyArray_ReturnsMinus1()
        {
            var s = new JumpOrderSearcher();
            int idx = s.SearchById(10, System.Array.Empty<Order>());
            Assert.Equal(-1, idx);
        }

        [Fact]
        public void ReturnsMinus1_WhenIdGreaterThanAll()
        {
            var s = new JumpOrderSearcher();
            int idx = s.SearchById(999, Orders()); // forces prev >= n branch
            Assert.Equal(-1, idx);
        }
    }
}
