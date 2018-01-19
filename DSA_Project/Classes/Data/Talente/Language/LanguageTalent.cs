using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    public class LanguageTalent : LanguageAbstractTalent
    {
        public LanguageTalent(string name, List<String> complex) : base(name, new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.CH }, complex) { }        
    }
}
