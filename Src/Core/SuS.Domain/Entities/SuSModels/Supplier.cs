using System.Collections.Generic;

namespace SuS.Domain.Entities.SuSModels
{
    public partial class Supplier
    {
        public Supplier()
        {
            AlternateName = new HashSet<AlternateName>();
            Branch = new HashSet<Branch>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public long? TypeId { get; set; }

        public Type Type { get; set; }
        public ICollection<AlternateName> AlternateName { get; set; }
        public ICollection<Branch> Branch { get; set; }
    }
}
