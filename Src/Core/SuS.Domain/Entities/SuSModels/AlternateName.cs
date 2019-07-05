namespace SuS.Domain.Entities.SuSModels
{
    public partial class AlternateName
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? SupplierId { get; set; }

        public Supplier Supplier { get; set; }
    }
}
