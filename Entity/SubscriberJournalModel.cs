using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class SubscriberJournalModel
    {
        public int Id { get; set; }
        public int SubscriberId { get; set; }
        public int JournalId { get; set; }
        public JournalModel Journal { get; set; }
        public SubscriberModel Subscriber { get; set; }
    }
}
