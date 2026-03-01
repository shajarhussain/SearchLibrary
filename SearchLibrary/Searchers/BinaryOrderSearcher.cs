using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchLibrary.Models;

namespace SearchLibrary.Searchers
{
    public class BinaryOrderSearcher : IOrderSearcher
    {
        public int SearchById(int id, Order[] ordersSortedById)
        {
            int bottom = 0;
            int top = ordersSortedById.Length - 1;

            while (bottom <= top)
            {
                int mid = (bottom + top) / 2;

                if (ordersSortedById[mid].Id == id)
                    return mid;

                if (ordersSortedById[mid].Id < id)
                    bottom = mid + 1;
                else
                    top = mid - 1;
            }

            return -1;
        }
    }
}
