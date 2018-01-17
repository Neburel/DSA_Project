using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    public class GiftTalent : notFighting
    {
        public GiftTalent(String name, List<DSA_ATTRIBUTE> probe) : base(name, probe, "", null, null)
        {
        }

        public override string getComplexName()
        {
            return this.getName();
        }
    }
}
