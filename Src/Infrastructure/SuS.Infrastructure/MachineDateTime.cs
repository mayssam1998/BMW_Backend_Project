using System;
using SuS.Common;

namespace SuS.Infrastructure
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;

        public int CurrentYear => DateTime.Now.Year;
    }
}
