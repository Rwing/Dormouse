using System;
using System.Collections.Generic;
using System.Text;

namespace Dormouse.Domain
{
    public class Period
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public IList<ShareItem> ShareItems { get; set; }
    }
}
