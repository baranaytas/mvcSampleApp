using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class JournalModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PublishCount { get; set; }
        public List<PublishModel> Publishes { get; set; }
    }
}
