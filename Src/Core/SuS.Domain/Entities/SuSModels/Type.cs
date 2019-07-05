using System.Collections.Generic;

namespace SuS.Domain.Entities.SuSModels
{
    public partial class Type
    {
        public Type()
        {
            Supplier = new HashSet<Supplier>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<Supplier> Supplier { get; set; }
    }
}
