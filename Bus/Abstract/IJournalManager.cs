using System.Collections.Generic;
using Entity;

namespace Bus.Abstract
{
    public interface IJournalManager
    {
        bool InsertJournal(JournalModel journalModel);

        bool Update(JournalModel journalModel);

        bool InsertPublish(PublishModel publishModel);

        bool Delete(int id);

        JournalModel Get(int id);

        List<JournalModel> GetAll();
    }
}
