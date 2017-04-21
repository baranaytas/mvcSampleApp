using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Abstract;

namespace Data.Repository
{
    public class SubscriberRepository : IGenericRepository<Subscriber>
    {
        private MedicalJournalEntities entities = new MedicalJournalEntities();

        public Subscriber Get(int id)
        {
            return entities.Subscribers.FirstOrDefault(x => x.Id == id);
        }
        public Subscriber Get(string username,string password)
        {
            return entities.Subscribers.FirstOrDefault(x => x.Username == username && x.Password == password);
        }

        public bool Insert(Subscriber model)
        {
            throw new NotImplementedException();
        }

        public bool Subcribe(SubscriberJournal model)
        {
            try
            {
                entities.SubscriberJournals.Add(model);
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool UnSubscribe(int id)
        {
            try
            {
                entities.SubscriberJournals.Remove(entities.SubscriberJournals.FirstOrDefault(x => x.Id == id));
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Subscriber> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}