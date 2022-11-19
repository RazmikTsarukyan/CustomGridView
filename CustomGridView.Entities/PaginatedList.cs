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
        public string OrderColumn { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte? Age { get; set; }
        public int? StatusId { get; set; }
    }
}
