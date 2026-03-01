using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchLibrary.Models;

namespace SearchLibrary.Searchers
{
    public class JumpOrderSearcher : IOrderSearcher
    {
        public int SearchById(int id, Order[] ordersSortedById)
        {
            int n = ordersSortedById.Length;
            if (n == 0) return -1;

            int step = (int)System.Math.Floor(System.Math.Sqrt(n));
            int prev = 0;

            while (prev < n && ordersSortedById[System.Math.Min(step, n) - 1].Id < id)
            {
                prev = step;
                step += (int)System.Math.Floor(System.Math.Sqrt(n));
                if (prev >= n) return -1;
            }

            while (prev < n && ordersSortedById[prev].Id < id)
                prev++;

            if (prev < n && ordersSortedById[prev].Id == id)
                return prev;

            return -1;
        }
    }
}
