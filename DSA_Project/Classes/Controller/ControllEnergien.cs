using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    public enum DSA_ENERGIEN { LEBENSENERGIE, AUSDAUER, ASTRALENERGIE, KARMAENERGIE, MAGIERESISTENZ }
    class ControllEnergien
    {
        static Dictionary<DSA_ENERGIEN, String> acronym = new Dictionary<DSA_ENERGIEN, String>()
        {
            { DSA_ENERGIEN.LEBENSENERGIE, "Leben"},
            { DSA_ENERGIEN.AUSDAUER, "Ausdauer"},
            { DSA_ENERGIEN.ASTRALENERGIE, "Astral"},
            { DSA_ENERGIEN.KARMAENERGIE, "Karma"},
            { DSA_ENERGIEN.MAGIERESISTENZ, "MR"},
        };

        public static String getAcronym(DSA_ENERGIEN energie)
        {
            String ret;
            acronym.TryGetValue(energie, out ret);
            return ret;
        }
    }
}
