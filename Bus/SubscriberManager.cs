using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bus.Abstract;
using Data;
using Data.Repository;
using Entity;

namespace Bus
{
    public class SubscriberManager:ISubscriberManager
    {

        private SubscriberRepository subscriberRepository;
        public SubscriberManager()
        {
            subscriberRepository = new SubscriberRepository();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public SubscriberJournalModel Get(string username)
        {
            throw new NotImplementedException();
        }

        public SubscriberModel Get(int id)
        {
            var subscribers = subscriberRepository.Get(id);
            return Mapper.Map<SubscriberModel>(subscribers);
        }

        public SubscriberModel Get(string username, string password)
        {
            var subscribers = subscriberRepository.Get(username,password);
            return Mapper.Map<SubscriberModel>(subscribers);
        }
    

        public bool Subscribe(SubscriberJournalModel subscriberJournalModel)
        {
            return subscriberRepository.Subcribe(Mapper.Map<SubscriberJournal>(subscriberJournalModel));
        }

        public bool Insert(SubscriberModel subscriberModel)
        {
            throw new NotImplementedException();
        }

        public bool Update(SubscriberModel subscriberModel)
        {
            throw new NotImplementedException();
        }

        public bool UnSubscribe(int id)
        {
            return subscriberRepository.UnSubscribe(id);
        }
    }
}
