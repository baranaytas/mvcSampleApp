using System;
using System.Collections.Generic;
using System.Linq;
using Data.Abstract;

namespace Data.Repository
{
    public class JournalRepository : IGenericRepository<Journal>
    {
        private MedicalJournalEntities entities=new MedicalJournalEntities();

        public bool Insert(Journal model)
        {
            try
            {
                entities.Journals.Add(model);
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public bool Insert(Publish model)
        {
            try
            {
                entities.Publishes.Add(model);
                entities.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(Journal model)
        {
            try
            {
                var journal = Get(model.Id);
                journal.Name = model.Name;
                journal.PublishCount = model.PublishCount;
                entities.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var temp = Get(id);
                entities.Journals.Remove(temp);
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Journal Get(int id)
        {
            return entities.Journals.FirstOrDefault(x => x.Id == id);
        }

        public List<Journal> GetAll()
        {
            return entities.Journals.ToList();
        }
    }
}
