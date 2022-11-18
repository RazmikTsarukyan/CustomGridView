using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGridView.Entities
{
    public class PlayerFilter
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte? Age { get; set; }
        public int? StatusId { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string OrderColumn { get; set; }
    }
}
