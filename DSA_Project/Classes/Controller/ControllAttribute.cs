using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    public enum DSA_ATTRIBUTE { MUT, KLUGHEIT, INTUITION, CHARISMA, FINGERFERTIGKEIT, GEWANDHEIT, KONSTITUTION, KÖRPERKRAFT, SOZAILSTATUS }
    
    static class ControllAttribute
    {
        static Dictionary<DSA_ATTRIBUTE, String> acronym = new Dictionary<DSA_ATTRIBUTE, String>()
        {
            { DSA_ATTRIBUTE.MUT, "MU"},
            { DSA_ATTRIBUTE.KLUGHEIT, "KL"},
            { DSA_ATTRIBUTE.CHARISMA, "CH"},
            { DSA_ATTRIBUTE.INTUITION, "IN"},
            { DSA_ATTRIBUTE.FINGERFERTIGKEIT, "FF"},
            { DSA_ATTRIBUTE.GEWANDHEIT, "GE"},
            { DSA_ATTRIBUTE.KONSTITUTION, "KO"},
            { DSA_ATTRIBUTE.KÖRPERKRAFT, "KK"},
            { DSA_ATTRIBUTE.SOZAILSTATUS, "SO"}
        };

        public static String getAcronym(DSA_ATTRIBUTE attribute)
        {
            String ret;
            acronym.TryGetValue(attribute, out ret);
            return ret;
        }

    }
}
