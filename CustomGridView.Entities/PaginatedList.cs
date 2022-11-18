using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGridView.Entities
{
    public class PaginatedPlayerList
    {
        public IEnumerable<Player> Players { get; set; } = new List<Player>();
        public int Total { get; set; } = 0;
    }
}
