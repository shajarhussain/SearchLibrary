using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchLibrary.Models;

namespace SearchLibrary.Searchers
{
    public interface IOrderSearcher
    {
        int SearchById(int id, Order[] ordersSortedById);
    }
}
