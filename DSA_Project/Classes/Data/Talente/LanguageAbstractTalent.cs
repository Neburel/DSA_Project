using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    public abstract class LanguageAbstractTalent : GeneralTalent
    {
        public LanguageAbstractTalent(String name, List<DSA_ATTRIBUTE> probe, int complex) : base(name, probe, complex.ToString(), null, null)
        {
        }
        public LanguageAbstractTalent(String name, List<DSA_ATTRIBUTE> probe, int complex1, int complex2) : base(name, probe, complex1.ToString() + "(" + complex2.ToString() + ")", null, null)
        {
        }
    }
}
