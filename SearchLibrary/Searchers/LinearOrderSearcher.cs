using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchLibrary.Models;

namespace SearchLibrary.Searchers
{
    public class LinearOrderSearcher : IOrderSearcher
    {
        public int SearchById(int id, Order[] ordersSortedById)
        {
            for (int i = 0; i < ordersSortedById.Length; i++)
            {
                if (ordersSortedById[i].Id == id)
                    return i;
            }
            return -1;
        }
    }
}
