// ﻿using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
// using SearchLibrary.Models;
// using SearchLibrary.Searchers;

// namespace SearchLibrary.Tests.Searchers
// {
//     public class BinaryOrderSearcherTests
//     {
//         private static Order[] Orders() => new[]
//         {
//             new Order { Id = 10, CustomerName = "A", TotalAmount = 100 },
//             new Order { Id = 20, CustomerName = "B", TotalAmount = 200 },
//             new Order { Id = 30, CustomerName = "C", TotalAmount = 300 },
//             new Order { Id = 40, CustomerName = "D", TotalAmount = 400 },
//             new Order { Id = 50, CustomerName = "E", TotalAmount = 500 }
//         };

//         [Fact]
//         public void FindsExistingOrder()
//         {
//             var s = new BinaryOrderSearcher();
//             int idx = s.SearchById(30, Orders());
//             Assert.Equal(2, idx);
//         }

//         [Fact]
//         public void ReturnsMinus1_WhenNotFound()
//         {
//             var s = new BinaryOrderSearcher();
//             int idx = s.SearchById(35, Orders());
//             Assert.Equal(-1, idx);
//         }
//     }
// }

using System;
using Xunit;
using SearchLibrary.Models;
using SearchLibrary.Searchers;

namespace SearchLibrary.Tests.Searchers
{
    public class BinaryOrderSearcherTests
    {
        private static Order[] Orders() => new[]
        {
            new Order { Id = 10, CustomerName = "A", TotalAmount = 100 },
            new Order { Id = 20, CustomerName = "B", TotalAmount = 200 },
            new Order { Id = 30, CustomerName = "C", TotalAmount = 300 },
            new Order { Id = 40, CustomerName = "D", TotalAmount = 400 },
            new Order { Id = 50, CustomerName = "E", TotalAmount = 500 }
        };

        /* ======== POSITIVE PATH ======== */
        [Fact]
        public void SearchById_FindsExistingOrder()
        {
            var searcher = new BinaryOrderSearcher();

            int index = searcher.SearchById(30, Orders());

            Assert.Equal(2, index);
        }

        /* ======== NEGATIVE PATH ======== */
        [Fact]
        public void SearchById_ReturnsMinus1_WhenOrderNotFound()
        {
            var searcher = new BinaryOrderSearcher();

            int index = searcher.SearchById(35, Orders());

            Assert.Equal(-1, index);
        }

        /* ======== EDGE CASE: EMPTY ARRAY ======== */
        [Fact]
        public void SearchById_ReturnsMinus1_WhenArrayIsEmpty()
        {
            var searcher = new BinaryOrderSearcher();

            int index = searcher.SearchById(10, Array.Empty<Order>());

            Assert.Equal(-1, index);
        }

        /* ======== EDGE CASE: SINGLE ELEMENT (FOUND) ======== */
        [Fact]
        public void SearchById_FindsOrder_WhenSingleElementExists()
        {
            var searcher = new BinaryOrderSearcher();
            var orders = new[]
            {
                new Order { Id = 99, CustomerName = "X", TotalAmount = 999 }
            };

            int index = searcher.SearchById(99, orders);

            Assert.Equal(0, index);
        }

        /* ======== EDGE CASE: SINGLE ELEMENT (NOT FOUND) ======== */
        [Fact]
        public void SearchById_ReturnsMinus1_WhenSingleElementDoesNotMatch()
        {
            var searcher = new BinaryOrderSearcher();
            var orders = new[]
            {
                new Order { Id = 99, CustomerName = "X", TotalAmount = 999 }
            };

            int index = searcher.SearchById(10, orders);

            Assert.Equal(-1, index);
        }

        /* ======== BOUNDARY CONDITIONS ======== */
        [Fact]
        public void SearchById_FindsFirstElement()
        {
            var searcher = new BinaryOrderSearcher();

            int index = searcher.SearchById(10, Orders());

            Assert.Equal(0, index);
        }

        [Fact]
        public void SearchById_FindsLastElement()
        {
            var searcher = new BinaryOrderSearcher();

            int index = searcher.SearchById(50, Orders());

            Assert.Equal(4, index);
        }
    }
}
