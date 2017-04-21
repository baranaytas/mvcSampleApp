using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Bus.Abstract
{
    public interface ISubscriberManager
    {
        bool Insert(SubscriberModel subscriberModel);

        bool Subscribe(SubscriberJournalModel subscriberJournalModel);

        bool UnSubscribe(int id);

        bool Update(SubscriberModel subscriberModel);

        bool Delete(int id);

        SubscriberModel Get(int id);

        SubscriberJournalModel Get(string username);

        SubscriberModel Get(string username, string password);
    }
}
