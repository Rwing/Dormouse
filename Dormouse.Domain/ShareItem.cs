using System;
using System.Collections.Generic;
using System.Text;

namespace Dormouse.Domain
{
    public class ShareItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }

        public int PeriodId { get; set; }
        public Period Period { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public IList<VoteItem> VoteItems { get; set; }
    }
}
