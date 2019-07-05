using System.Collections.Generic;

namespace SuS.Common.Models
{
    public class Talend
    {
        public Talend()
        {
            Jobs = new Dictionary<string, Job>();
        }
        public Dictionary<string, Job> Jobs { get; private set; }
    }
}

