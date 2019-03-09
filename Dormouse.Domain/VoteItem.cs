using System;
using System.Collections.Generic;
using System.Text;

namespace Dormouse.Domain
{
    public class VoteItem
    {
        public int Id { get; set; }

        public User User { get; set; }
        public ShareItem ShareItem { get; set; }
        public Period Period { get; set; }
    }
}
