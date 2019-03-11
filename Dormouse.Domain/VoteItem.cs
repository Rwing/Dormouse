using System;
using System.Collections.Generic;
using System.Text;

namespace Dormouse.Domain
{
    public class VoteItem
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public int UserId { get; set; }
        public bool UpOrDown { get; set; }

        public User User { get; set; }
        public int ShareItemId { get; set; }
        public ShareItem ShareItem { get; set; }
        public int PeriodId { get; set; }
        public Period Period { get; set; }
    }
}
