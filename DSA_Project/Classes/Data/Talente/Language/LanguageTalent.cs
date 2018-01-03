using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    public class LanguageTalent : LanguageAbstractTalent
    {
        private FontTalent fontTalent = null;

        public LanguageTalent(String FamilyName, string name, int complex) : base(FamilyName, name, new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.CH }, complex)
        { }
        public LanguageTalent(String FamilyName, string name, int complex, int complex2) : base(FamilyName, name, new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.CH }, complex, complex2)
        { }
        
    }
}
