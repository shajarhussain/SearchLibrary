using System;
using SearchLibrary.Models;

namespace SearchLibrary.Searchers
{
    public class InterpolationOrderSearcher
    {
        public int SearchById(int targetId, Order[] orders)
        {
            if (orders == null || orders.Length == 0)
                return -1;

            int low = 0;
            int high = orders.Length - 1;

            while (low <= high &&
                   targetId >= orders[low].Id &&
                   targetId <= orders[high].Id)
            {
                // Prevent division by zero
                if (orders[high].Id == orders[low].Id)
                {
                    if (orders[low].Id == targetId)
                        return low;
                    return -1;
                }

                int pos = low + (int)(
                    ((double)(targetId - orders[low].Id) /
                    (orders[high].Id - orders[low].Id)) *
                    (high - low)
                );

                if (orders[pos].Id == targetId)
                    return pos;

                if (orders[pos].Id < targetId)
                    low = pos + 1;
                else
                    high = pos - 1;
            }

            return -1;
        }
    }
}
