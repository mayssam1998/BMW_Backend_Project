namespace SuS.Domain.Entities.SuSModels
{
    public partial class Branch
    {
        public long Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string PostCode { get; set; }
        public long? StreetId { get; set; }
        public long? SupplierId { get; set; }

        public Street Street { get; set; }
        public Supplier Supplier { get; set; }
    }
}
