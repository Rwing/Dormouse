using System;
using System.Collections.Generic;
using System.Text;

namespace Dormouse.Domain
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<Period> Periods { get; set; }
    }
}
