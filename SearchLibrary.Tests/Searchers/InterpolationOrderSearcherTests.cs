using System;
using Xunit;
using SearchLibrary.Models;
using SearchLibrary.Searchers;

namespace SearchLibrary.Tests.Searchers
{
    public class InterpolationOrderSearcherTests
    {
        private static Order[] Orders() => new[]
        {
            new Order { Id = 10, CustomerName = "A", TotalAmount = 100 },
            new Order { Id = 20, CustomerName = "B", TotalAmount = 200 },
            new Order { Id = 30, CustomerName = "C", TotalAmount = 300 },
            new Order { Id = 40, CustomerName = "D", TotalAmount = 400 },
            new Order { Id = 50, CustomerName = "E", TotalAmount = 500 }
        };

        /* ======== POSITIVE PATHS ======== */

        [Fact]
        public void SearchById_FindsFirstElement()
        {
            var searcher = new InterpolationOrderSearcher();

            int index = searcher.SearchById(10, Orders());

            Assert.Equal(0, index);
        }

        [Fact]
        public void SearchById_FindsMiddleElement()
        {
            var searcher = new InterpolationOrderSearcher();

            int index = searcher.SearchById(30, Orders());

            Assert.Equal(2, index);
        }

        [Fact]
        public void SearchById_FindsLastElement()
        {
            var searcher = new InterpolationOrderSearcher();

            int index = searcher.SearchById(50, Orders());

            Assert.Equal(4, index);
        }

        /* ======== NEGATIVE PATHS ======== */

        [Fact]
        public void SearchById_ReturnsMinus1_WhenNotFound()
        {
            var searcher = new InterpolationOrderSearcher();

            int index = searcher.SearchById(35, Orders());

            Assert.Equal(-1, index);
        }

        [Fact]
        public void SearchById_ReturnsMinus1_WhenIdLessThanAllElements()
        {
            var searcher = new InterpolationOrderSearcher();

            int index = searcher.SearchById(1, Orders());

            Assert.Equal(-1, index);
        }

        [Fact]
        public void SearchById_ReturnsMinus1_WhenIdGreaterThanAllElements()
        {
            var searcher = new InterpolationOrderSearcher();

            int index = searcher.SearchById(999, Orders());

            Assert.Equal(-1, index);
        }

        /* ======== EDGE CASES ======== */

        [Fact]
        public void SearchById_ReturnsMinus1_WhenArrayIsEmpty()
        {
            var searcher = new InterpolationOrderSearcher();

            int index = searcher.SearchById(10, Array.Empty<Order>());

            Assert.Equal(-1, index);
        }

        [Fact]
        public void SearchById_FindsOrder_WhenSingleElementExists()
        {
            var searcher = new InterpolationOrderSearcher();
            var orders = new[]
            {
                new Order { Id = 77, CustomerName = "X", TotalAmount = 770 }
            };

            int index = searcher.SearchById(77, orders);

            Assert.Equal(0, index);
        }

        [Fact]
        public void SearchById_ReturnsMinus1_WhenSingleElementDoesNotMatch()
        {
            var searcher = new InterpolationOrderSearcher();
            var orders = new[]
            {
                new Order { Id = 77, CustomerName = "X", TotalAmount = 770 }
            };

            int index = searcher.SearchById(10, orders);

            Assert.Equal(-1, index);
        }
    }
}
