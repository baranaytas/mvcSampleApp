using System.Collections.Generic;
using AutoMapper;
using Bus.Abstract;
using Data;
using Data.Repository;
using Entity;

namespace Bus
{
    public class JournalManager : IJournalManager
    {
        private JournalRepository journalRepository;
        public JournalManager()
        {
            journalRepository = new JournalRepository();
        }

        public bool InsertJournal(JournalModel journalModel)
        {
            return journalRepository.Insert(Mapper.Map<Journal>(journalModel));
        }

        public bool InsertPublish(PublishModel publishModel)
        {
            return journalRepository.Insert(Mapper.Map<Publish>(publishModel));
        }

        public bool Update(JournalModel journalModel)
        {
            return journalRepository.Update(Mapper.Map<Journal>(journalModel));
        }

        public bool Delete(int id)
        {
            return journalRepository.Delete(id);
        }

        public JournalModel Get(int id)
        {
            var journals = journalRepository.Get(id);
            return Mapper.Map<JournalModel>(journals);
        }

        public List<JournalModel> GetAll()
        {
            var journals = journalRepository.GetAll();
            return Mapper.Map<List<JournalModel>>(journals);
        }
    }
}
