using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PublishModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int JournalId { get; set; }
        public System.DateTime PublishDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
