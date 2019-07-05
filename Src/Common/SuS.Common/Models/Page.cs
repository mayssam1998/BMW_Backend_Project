using System.Collections.Generic;

namespace SuS.Common.Models
{
    public class Page<T>
    {
        public List<T> Results { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public long RecordCount { get; set; }
    }
}