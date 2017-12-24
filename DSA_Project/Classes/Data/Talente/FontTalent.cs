using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    public class FontTalent : LanguageAbstractTalent
    {
        public FontTalent(string name, int complex) : base(name, new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.FF}, complex)
        {

        }

        public FontTalent(string name, int complex, int complex2) : base(name, new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.FF }, complex, complex2)
        {

        }
    }
}
