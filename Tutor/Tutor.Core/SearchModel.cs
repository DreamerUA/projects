using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutor.Core
{
    public class SearchModel
    {
        public string Word { get; set; }
        public string City { get; set; }
        public int Payment { get; set; }
        public string Gender { get; set; }
        public string Education { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
    }
}
